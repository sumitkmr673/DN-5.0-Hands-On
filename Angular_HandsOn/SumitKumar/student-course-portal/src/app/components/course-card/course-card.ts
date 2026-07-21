import { Component, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreditLabelPipe } from '../../pipes/credit-label-pipe';

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

  isEnrolled: boolean = false;
  isExpanded: boolean = false;

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

  onEnroll() {
    this.isEnrolled = true;
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
