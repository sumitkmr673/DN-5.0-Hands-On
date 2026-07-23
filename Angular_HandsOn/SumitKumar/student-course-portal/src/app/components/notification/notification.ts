import { Component } from '@angular/core';
import { NotificationService } from '../../services/notification';

@Component({
  selector: 'app-notification',
  standalone: true,
  imports: [],
  providers: [NotificationService],
  templateUrl: './notification.html',
  styleUrl: './notification.css',
})
export class Notification {
  /**
   * By providing NotificationService in the @Component 'providers' array,
   * Angular's Dependency Injection system creates a new, separate instance
   * of the service that is strictly scoped to this specific component instance
   * and its children. It does not share state with the rest of the app like a
   * global 'root' singleton would.
   */

  constructor(private notificationService: NotificationService) {}
}
