import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ReactiveFormsModule,
  FormBuilder,
  FormGroup,
  Validators,
  AbstractControl,
  ValidationErrors,
  FormArray,
} from '@angular/forms';

export function noCourseCode(control: AbstractControl): ValidationErrors | null {
  if (
    control.value &&
    typeof control.value === 'string' &&
    control.value.toUpperCase().startsWith('XX')
  ) {
    return { noCourseCode: true };
  }
  return null;
}

export function simulateEmailCheck(control: AbstractControl): Promise<ValidationErrors | null> {
  return new Promise((resolve) => {
    setTimeout(() => {
      if (control.value && control.value.includes('test@')) {
        resolve({ emailTaken: true });
      } else {
        resolve(null);
      }
    }, 800);
  });
}

@Component({
  selector: 'app-reactive-enrollment-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './reactive-enrollment-form.html',
  styleUrl: './reactive-enrollment-form.css',
})
export class ReactiveEnrollmentForm implements OnInit {
  enrollForm!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.enrollForm = this.fb.group({
      studentName: ['', [Validators.required, Validators.minLength(3)]],
      studentEmail: ['', [Validators.required, Validators.email], [simulateEmailCheck]],
      courseId: ['', [Validators.required, noCourseCode]],
      preferredSemester: ['Odd', Validators.required],
      agreeToTerms: [false, Validators.requiredTrue],
      additionalCourses: this.fb.array([]),
    });
  }

  get additionalCourses(): FormArray {
    return this.enrollForm.get('additionalCourses') as FormArray;
  }

  /**
   * This getter is better than casting in the template because
   * 1. It keeps the template clean and readable.
   * 2. In ensures strong typing within the TypeScript class.
   * 3. Angular templates don't natively undestand that enrollForm.get() returns
   *    a FormArray, which can cause strict-mode template compiilation errors if not cast properly.
   */

  addCourse() {
    this.additionalCourses.push(this.fb.control('', Validators.required));
  }

  removeCourse(index: number) {
    this.additionalCourses.removeAt(index);
  }

  onSubmit() {
    console.log('Form .value:', this.enrollForm.value);
    console.log('Form .getRawValue():', this.enrollForm.getRawValue());

    // DIFFERENCE: enrollForm.value excludes any form controls that are dynamically disabled.
    // enrollForm.getRawValue() includes the values of ALL controls, even if they are disabled.
  }
}
