import { Injectable } from '@angular/core';
import { CourseService } from './course';
import { Course } from '../models/course.model';
import { Observable, of, map, delay } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EnrollmentService {
  private enrolledCourseIds: (string | number)[] = [];

  constructor(private courseService: CourseService) {}

  enroll(courseId: string | number): void {
    if (!this.enrolledCourseIds.includes(courseId)) {
      this.enrolledCourseIds.push(courseId);
    }
  }

  unenroll(courseId: string | number): void {
    this.enrolledCourseIds = this.enrolledCourseIds.filter((id) => id !== courseId);
  }

  isEnrolled(courseId: string | number): boolean {
    return this.enrolledCourseIds.includes(courseId);
  }

  getEnrolledCourses(): Observable<Course[]> {
    return this.courseService
      .getCourses()
      .pipe(
        map((courses: Course[]) =>
          courses.filter((course: Course) => this.enrolledCourseIds.includes(course.id)),
        ),
      );
  }

  getStudentsByCourse(courseId: string | number): Observable<string[]> {
    console.log(`Making HTTP request for students in course: ${courseId}`);
    return of(['John Doe', 'Jane Smith', 'Alice Johnson']).pipe(delay(2000));
  }
}
