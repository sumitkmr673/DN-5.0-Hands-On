import { HighlightDirective } from '../../directives/highlight';
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CourseCard } from '../../components/course-card/course-card';
import { Course } from '../../models/course.model';
import { CourseService } from '../../services/course';
import { CourseSummaryWidget } from '../../components/course-summary-widget/course-summary-widget';
import { Subject, switchMap } from 'rxjs';
import { EnrollmentService } from '../../services/enrollment';

import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-course-list',
  standalone: true,
  imports: [
    CommonModule,
    CourseCard,
    HighlightDirective,
    CourseSummaryWidget,
    FormsModule,
    RouterModule,
  ],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css',
})
export class CourseList implements OnInit {
  isLoading = true;
  courses: Course[] = [];
  errorMessage: string = '';

  selectedCourseId?: string | number;
  searchTerm: string = '';

  courseSelection$ = new Subject<string | number>();
  studentsForCourse: string[] = [];

  constructor(
    private courseService: CourseService,
    private enrollmentService: EnrollmentService,
    private router: Router,
    private route: ActivatedRoute,
    private http: HttpClient,
  ) {}

  simulate401() {
    this.http.get('https://httpstat.us/401').subscribe();
  }

  ngOnInit(): void {
    const savedSearch = this.route.snapshot.queryParamMap.get('search');
    if (savedSearch) {
      this.searchTerm = savedSearch;
    }

    this.courseService.getCourses().subscribe({
      next: (courses) => {
        this.courses = courses;
      },
      error: (err) => {
        this.errorMessage = err.message;
        this.isLoading = false;
      },
      complete: () => {
        this.isLoading = false;
      },
    });

    this.courseSelection$
      .pipe(
        /**
         * switchMap is essential here because it cancels the previous inner Observable (HTTP request)
         * if a new courseId arrives before the first completes. This prevents out-of-order
         * responses if the user clicks multiple courses rapidly.
         */
        switchMap((courseId) => this.enrollmentService.getStudentsByCourse(courseId)),
      )
      .subscribe((students) => {
        this.studentsForCourse = students;
        console.log('Students loaded successfully:', students);
      });

    setTimeout(() => {
      this.isLoading = false;
    }, 1500);
  }

  viewCourseDetails(courseId: string | number): void {
    this.router.navigate(['courses', courseId]);
  }

  onSearch(): void {
    this.router.navigate(['courses'], {
      queryParams: { search: this.searchTerm || null },
    });
  }

  onEnroll(courseId: string | number) {
    console.log('Enrolling in course: ' + courseId);
    this.selectedCourseId = courseId;

    this.studentsForCourse = [];
    this.courseSelection$.next(courseId);
  }

  onDelete(courseId: string | number): void {
    this.courseService.deleteCourse(courseId).subscribe({
      next: () => {
        console.log(`Course ${courseId} successfully deleted from backend.`);

        this.courses = this.courses.filter((course) => course.id !== courseId);
      },
      error: (err) => {
        console.error('Error deleting course:', err);
      },
    });
  }

  /**
   * trackBy improves performancec by tracking items via a unique identifier (like ID)
   * instead of of object identity. When the array changes, Angular only re-renders the specific
   * DOM elements that changed, rather than destroying and recreating the entire list.
   */

  trackByCourseId(index: number, course: Course): string | number {
    return course.id;
  }

  addDummyCourse() {
    const newCourse = {
      name: 'New Dynamic Course',
      code: 'NEW',
      credits: 3,
      gradeStatus: 'pending' as const,
    };

    this.courseService.createCourse(newCourse).subscribe({
      next: (createdCourse) => {
        console.log('Course added to DB:', createdCourse);
        this.courses.push(createdCourse);
      },
      error: (err) => {
        console.error('Error adding course:', err);
      },
    });
  }
}
