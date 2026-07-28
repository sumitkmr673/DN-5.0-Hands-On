import { Component, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { CreditLabelPipe } from '../../pipes/credit-label-pipe';
import { Course } from '../../models/course.model';
import { enrollInCourse, unenrollFromCourse } from '../../store/enrollment/enrollment-actions';
import { selectEnrolledIds } from '../../store/enrollment/enrollment-selectors';

@Component({
  selector: 'app-course-card',
  standalone: true,
  imports: [CommonModule, CreditLabelPipe],
  templateUrl: './course-card.html',
  styleUrl: './course-card.css',
})
export class CourseCard implements OnChanges {
  @Input() course!: Course;

  @Output() enrollRequested = new EventEmitter<string | number>();
  @Output() delete = new EventEmitter<string | number>();

  isExpanded: boolean = false;
  enrolledIds$: Observable<(string | number)[]>;

  // 1. Inject the Store instead of EnrollmentService
  constructor(private store: Store) {
    this.enrolledIds$ = this.store.select(selectEnrolledIds);
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['course']) {
      console.log(
        'Course changed - Previous:',
        changes['course'].previousValue,
        'Current:',
        changes['course'].currentValue,
      );
    }
  }

  onDelete(event: MouseEvent): void {
    event.stopPropagation();
    this.delete.emit(this.course.id);
  }

  // 2. We pass the isEnrolled boolean directly from the HTML template now!
  onEnroll(event: MouseEvent, isEnrolled: boolean): void {
    event.stopPropagation();
    if (isEnrolled) {
      this.store.dispatch(unenrollFromCourse({ courseId: this.course.id }));
    } else {
      this.store.dispatch(enrollInCourse({ courseId: this.course.id }));
    }
    this.enrollRequested.emit(this.course.id);
  }

  toggleDetails() {
    this.isExpanded = !this.isExpanded;
  }

  getBorderColor(): string {
    switch (this.course.gradeStatus) {
      case 'passed':
        return 'green';
      case 'failed':
        return 'red';
      case 'pending':
        return 'grey';
      default:
        return 'transparent';
    }
  }

  // Notice: get isEnrolled() and get cardClasses() are completely GONE!
}
