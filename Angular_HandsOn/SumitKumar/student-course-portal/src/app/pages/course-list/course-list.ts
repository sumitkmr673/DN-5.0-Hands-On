import { HighlightDirective } from '../../directives/highlight';
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CourseCard } from '../../components/course-card/course-card';
import { Course } from '../../models/course.model';
import { CourseService } from '../../services/course';
import { CourseSummaryWidget } from '../../components/course-summary-widget/course-summary-widget';

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
  selectedCourseId?: number;
  searchTerm: string = '';

  constructor(
    private courseService: CourseService,
    private router: Router,
    private route: ActivatedRoute,
  ) {}

  ngOnInit(): void {
    this.courses = this.courseService.getCourses();

    const savedSearch = this.route.snapshot.queryParamMap.get('search');
    if (savedSearch) {
      this.searchTerm = savedSearch;
    }
    setTimeout(() => {
      this.isLoading = false;
    }, 1500);
  }

  viewCourseDetails(courseId: number): void {
    this.router.navigate(['courses', courseId]);
  }

  onSearch(): void {
    this.router.navigate(['courses'], {
      queryParams: { search: this.searchTerm || null },
    });
  }

  onEnroll(courseId: number) {
    console.log('Enrolling in course: ' + courseId);
    this.selectedCourseId = courseId;
  }

  /**
   * trackBy improves performancec by tracking items via a unique identifier (like ID)
   * instead of of object identity. When the array changes, Angular only re-renders the specific
   * DOM elements that changed, rather than destroying and recreating the entire list.
   */

  trackByCourseId(index: number, course: Course): number {
    return course.id;
  }

  addDummyCourse() {
    const newCourse: Course = {
      id: Math.floor(Math.random() * 1000),
      name: 'New Dynamic Course',
      code: 'NEW999',
      credits: 3,
      gradeStatus: 'pending',
    };
    this.courseService.addCourse(newCourse);
  }
}
