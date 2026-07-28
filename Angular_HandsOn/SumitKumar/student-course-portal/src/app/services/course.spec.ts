import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { CourseService } from './course';
import { Course } from '../models/course.model';

describe('CourseService', () => {
  let service: CourseService;
  let httpMock: HttpTestingController;

  const mockCourses: Course[] = [
    { id: 1, name: 'Angular Basics', code: 'ANG101', credits: 3, gradeStatus: 'passed' },
    { id: 2, name: 'RxJS Advanced', code: 'RJS102', credits: 3, gradeStatus: 'pending' },
  ];

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [CourseService],
    });
    service = TestBed.inject(CourseService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should retrieve courses from the API', () => {
    service.getCourses().subscribe((courses) => {
      expect(courses.length).toBe(2);
      expect(courses).toEqual(mockCourses);
    });

    const req = httpMock.expectOne('http://localhost:3000/courses');
    expect(req.request.method).toBe('GET');
    req.flush(mockCourses);
  });

  it('should handle a 500 error', () => {
    service.getCourses().subscribe({
      next: () => fail('should have failed with the 500 error'),
      error: (error) => {
        expect(error.message).toBe('Failed to load courses. Please try again.');
      },
    });

    const req1 = httpMock.expectOne('http://localhost:3000/courses');
    expect(req1.request.method).toBe('GET');
    req1.flush('Server Error', {
      status: 500,
      statusText: 'Internal Server Error',
    });

    const req2 = httpMock.expectOne('http://localhost:3000/courses');
    expect(req2.request.method).toBe('GET');
    req2.flush('Server Error', {
      status: 500,
      statusText: 'Internal Server Error',
    });

    const req3 = httpMock.expectOne('http://localhost:3000/courses');
    expect(req3.request.method).toBe('GET');
    req3.flush('Server Error', {
      status: 500,
      statusText: 'Internal Server Error',
    });
  });
});
