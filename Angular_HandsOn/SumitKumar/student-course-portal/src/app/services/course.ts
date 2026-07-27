import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError, tap, retry } from 'rxjs/operators';
import { Course } from '../models/course.model';

@Injectable({
  providedIn: 'root',
})
export class CourseService {
  private apiUrl = 'http://localhost:3000/courses';

  constructor(private http: HttpClient) {}

  getCourses(): Observable<Course[]> {
    return this.http.get<Course[]>(this.apiUrl).pipe(
      // 1. retry(2): Retries failed HTTP requests up to 2 times before propagating the error
      retry(2),

      // 2. tap(): tap is preferred over side effects inside map because tap is designed
      // strictly for side effects (like logging). It does not alter the observable stream,
      // allowing map to remain a pure function used only for data transformation.
      tap((courses) => console.log('Courses loaded:', courses.length)),

      // 3. map(): Transforms the API response before it reaches the component
      map((courses) => courses.filter((c) => c.credits > 0)),

      // 4. catchError(): Intercepts errors and returns a custom error message
      catchError((err) => {
        console.error(err);
        return throwError(() => new Error('Failed to load courses. Please try again.'));
      }),
    );
  }

  getCourseById(id: string | number): Observable<Course> {
    return this.http.get<Course>(`${this.apiUrl}/${id}`);
  }

  createCourse(course: Omit<Course, 'id'>): Observable<Course> {
    return this.http.post<Course>(this.apiUrl, course);
  }

  updateCourse(id: string | number, course: Partial<Course>): Observable<Course> {
    return this.http.put<Course>(`${this.apiUrl}/${id}`, course);
  }

  deleteCourse(id: string | number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
