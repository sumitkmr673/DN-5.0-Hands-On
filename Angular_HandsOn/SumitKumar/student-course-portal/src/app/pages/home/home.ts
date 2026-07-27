import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CourseService } from '../../services/course';

@Component({
  selector: 'app-home',
  imports: [FormsModule],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  portalName = 'Student Course Portal';
  isPortalActive = true;
  message = '';
  searchTerm = '';

  constructor(private courseService: CourseService) {}

  totalCourses: number = 0;
  ngOnInit(): void {
    this.courseService.getCourses().subscribe((courses) => {
      this.totalCourses = courses.length;
    });
    console.log('Home initialized - courses loaded');
  }

  onEnrollClick() {
    this.message = 'Enrollment opened!';
  }

  ngOnDestroy() {
    console.log('Home Destroyed');
  }

  /**
   * [property] is a one-way data binding from the component class to the DOM element.
   * [(ngModel)] is a two-way data binding that keeps the component class and the DOM completely synchronized in real-time (DOM <-> component).
   */
}
