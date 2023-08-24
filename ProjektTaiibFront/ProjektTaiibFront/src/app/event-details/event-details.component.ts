import { Component } from '@angular/core';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})
export class EventDetailsComponent {

  get isLoggedIn() : boolean {
    const token = localStorage.getItem('token');
    console.log('token ',token)
    return token != null && token.length > 0;
  }
}
