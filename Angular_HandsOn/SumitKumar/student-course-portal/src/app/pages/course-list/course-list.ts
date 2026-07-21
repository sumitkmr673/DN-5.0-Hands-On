import { HighlightDirective } from '../../directives/highlight';
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseCard } from '../../components/course-card/course-card';

@Component({
  selector: 'app-course-list',
  standalone: true,
  imports: [CommonModule, CourseCard, HighlightDirective],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css',
})
export class CourseList implements OnInit {
  isLoading = true;

  courses = [
    { id: 101, name: 'Angular Fundamentals', code: 'CS101', credits: 3, gradeStatus: 'passed' },
    { id: 102, name: 'Advanced RxJS', code: 'CS201', credits: 4, gradeStatus: 'pending' },
    { id: 103, name: 'State Management', code: 'CS301', credits: 3, gradeStatus: 'failed' },
    { id: 104, name: 'TypeScript Deep Dive', code: 'CS401', credits: 4, gradeStatus: 'passed' },
    { id: 105, name: 'Web Performance', code: 'CS501', credits: 2, gradeStatus: 'pending' },
  ];

  selectedCourseId?: number;

  ngOnInit(): void {
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

  trackByCourseId(index: number, course: any): number {
    return course.id;
  }
}
