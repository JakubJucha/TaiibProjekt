import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventsService } from '../events.service';
import { Events } from '../models/event';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})
export class EventDetailsComponent implements OnInit {
  currentEvent: Events = new Events();

  constructor(private _route: ActivatedRoute,
              private _eventService: EventsService) {}

  ngOnInit(): void {
    this._route.paramMap.subscribe(params => {
      const eventIdParam = params.get('eventId');
      
      if (eventIdParam !== null) {
        const eventId = +eventIdParam;
        if (!isNaN(eventId)) {
          this._eventService.getEventById(eventId).subscribe({
            next: res => {
              this.currentEvent = res;
            },
            error: err => {
              console.log('Błąd pobierania wydarzenia.');
              
            }
          })
        } else {
          console.error('Invalid eventId parameter');
        }
      } else {
        console.error('eventId parameter is missing');
      }
    });
  }

  get isLoggedIn() : boolean {
    const token = localStorage.getItem('token');
    return token != null && token.length > 0;
  }

}
