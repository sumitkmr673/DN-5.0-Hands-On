import { HighlightDirective } from '../../directives/highlight';
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseCard } from '../../components/course-card/course-card';
import { Course } from '../../models/course.model';
import { CourseService } from '../../services/course';
import { CourseSummaryWidget } from '../../components/course-summary-widget/course-summary-widget';

@Component({
  selector: 'app-course-list',
  standalone: true,
  imports: [CommonModule, CourseCard, HighlightDirective, CourseSummaryWidget],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css',
})
export class CourseList implements OnInit {
  isLoading = true;

  courses: Course[] = [];

  selectedCourseId?: number;

  constructor(private courseService: CourseService) {}

  ngOnInit(): void {
    this.courses = this.courseService.getCourses();
    setTimeout(() => {
      this.isLoading = false;
    }, 1500);
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
