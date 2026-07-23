import { Injectable } from '@angular/core';
import { Course } from '../models/course.model';

@Injectable({
  providedIn: 'root',
})
export class CourseService {
  private courses: Course[] = [
    { id: 1, name: 'Angular Basics', code: 'CS101', credits: 3, gradeStatus: 'passed' },
    { id: 2, name: 'Reactive Forms', code: 'CS102', credits: 4, gradeStatus: 'pending' },
    { id: 3, name: 'RxJS Streams', code: 'CS103', credits: 3, gradeStatus: 'failed' },
    { id: 4, name: 'State Management', code: 'CS104', credits: 4, gradeStatus: 'pending' },
    { id: 5, name: 'Deployment', code: 'CS105', credits: 2, gradeStatus: 'passed' },
  ];

  constructor() {}

  getCourses(): Course[] {
    return this.courses;
  }

  getCourseById(id: number): Course | undefined {
    return this.courses.find((course) => course.id === id);
  }

  addCourse(course: Course): void {
    this.courses.push(course);
  }
}
