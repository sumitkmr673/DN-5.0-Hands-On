/// <reference types="jasmine" />
import { vi } from 'vitest'; // because this projeect is built on vitest as its the modern framework
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { SimpleChange } from '@angular/core';
import { provideMockStore, MockStore } from '@ngrx/store/testing';

import { CourseCard } from './course-card';
import { Course } from '../../models/course.model';

describe('CourseCard', () => {
  let component: CourseCard;
  let fixture: ComponentFixture<CourseCard>;
  let store: MockStore;

  const initialState = {
    enrollment: { enrolledCourseIds: [] },
  };

  const mockCourse: Course = {
    id: 1,
    name: 'Data Structures',
    code: 'CS101',
    credits: 4,
    gradeStatus: 'passed',
  };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CourseCard],
      providers: [provideMockStore({ initialState })],
    }).compileComponents();

    store = TestBed.inject(MockStore);
    fixture = TestBed.createComponent(CourseCard);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    component.course = mockCourse;
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });

  it('should display the course name based on @Input', () => {
    component.course = mockCourse;
    fixture.detectChanges();

    const h3Element = fixture.debugElement.query(By.css('h3')).nativeElement;
    expect(h3Element.textContent).toContain('Data Structures');
    expect(h3Element.textContent).toContain('CS101');
  });

  it('should emit enrollRequested event when Enroll button is clicked', () => {
    component.course = mockCourse;
    fixture.detectChanges();

    vi.spyOn(component.enrollRequested, 'emit');

    const buttons = fixture.debugElement.queryAll(By.css('button'));
    const enrollButton = buttons[1].nativeElement;
    enrollButton.click();

    fixture.detectChanges();

    expect(component.enrollRequested.emit).toHaveBeenCalledWith(1);
  });

  // Step 105: Test ngOnChanges lifecycle hook
  it('should log previous and current values on ngOnChanges', () => {
    // Spy on the global console.log
    vi.spyOn(console, 'log');

    component.course = mockCourse;

    const changes = {
      course: new SimpleChange(null, mockCourse, true),
    };

    component.ngOnChanges(changes as any);

    expect(console.log).toHaveBeenCalled();
    expect(console.log).toHaveBeenCalledWith(
      'Course changed - Previous:',
      null,
      'Current:',
      mockCourse,
    );
  });
});
