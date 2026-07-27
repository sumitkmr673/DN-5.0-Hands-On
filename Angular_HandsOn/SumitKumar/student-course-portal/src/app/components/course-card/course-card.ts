import { Component, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreditLabelPipe } from '../../pipes/credit-label-pipe';
import { EnrollmentService } from '../../services/enrollment';

@Component({
  selector: 'app-course-card',
  standalone: true,
  imports: [CommonModule, CreditLabelPipe],
  templateUrl: './course-card.html',
  styleUrl: './course-card.css',
})
export class CourseCard implements OnChanges {
  @Input() course!: {
    id: number;
    name: string;
    code: string;
    credits: number;
    gradeStatus: string;
  };
  @Output() enrollRequested = new EventEmitter<number>();

  isExpanded: boolean = false;

  constructor(private enrollmentService: EnrollmentService) {}

  get isEnrolled(): boolean {
    if (!this.course) return false;
    return this.enrollmentService.isEnrolled(this.course.id);
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

  onEnroll(event: MouseEvent): void {
    event.stopPropagation();
    if (this.isEnrolled) {
      this.enrollmentService.unenroll(this.course.id);
    } else {
      this.enrollmentService.enroll(this.course.id);
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

  /**
   * getters keep templates clean by moving complex conditional logic out of the HTML
   * and into the TypeScript class. This improves readability, makes testing easier,
   * and prevents the template deom becoming cluttered with business logic.
   */

  get cardClasses() {
    return {
      'card--enrolled': this.isEnrolled,
      'card--full': this.course.credits >= 4,
      expanded: this.isExpanded,
    };
  }
}
