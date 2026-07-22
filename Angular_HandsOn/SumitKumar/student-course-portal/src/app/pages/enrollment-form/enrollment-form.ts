import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-enrollment-form',
  imports: [CommonModule, FormsModule],
  templateUrl: './enrollment-form.html',
  styleUrl: './enrollment-form.css',
})
export class EnrollmentForm {
  studentNameInput: string = '';
  studentEmailInput: string = '';
  courseIdInput: number | null = null;
  semesterInput: string = '';
  agreeInput: boolean = false;

  submitted: boolean = false;

  onSubmit(form: NgForm) {
    console.log('Form Values: ', form.value);
    console.log('Is Form Valid?: ', form.valid);
    this.submitted = true;
  }
}
