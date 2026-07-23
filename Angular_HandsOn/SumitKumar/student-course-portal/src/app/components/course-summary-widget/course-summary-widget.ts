import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseService } from '../../services/course';

@Component({
  selector: 'app-course-summary-widget',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div
      style="border: 2px solid #007bff; padding: 15px; margin-bottom: 20px; border-radius: 5px; background-color: #f8f9fa;"
    >
      <h3 style="margin-top: 0;">Live Course Summary</h3>
      <p style="margin-bottom: 0; font-size: 1.2rem;">
        Total Courses in Service: <strong>{{ courseCount }}</strong>
      </p>
    </div>
  `,
})
export class CourseSummaryWidget {
  constructor(private courseService: CourseService) {}

  get courseCount(): number {
    return this.courseService.getCourses().length;
  }
}
