import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Event} from './models/event'

@Injectable({
  providedIn: 'root'
})
export class EventsService {
  

  constructor(private _http: HttpClient,) { }

  getAllEvents(): Event[] | null {
    let allEvents: Event[] = [];
    const apiUrl = `http://localhost:5168/api/user/event/getAll`;
    this._http.get(apiUrl).subscribe({
      next: (res: any) => {
          allEvents = res.map((eventData: any) => new Event(
            eventData.eventName,
            eventData.location,
            eventData.date,
            eventData.description,
            eventData.category,
            eventData.amountTickt,
            eventData.ticketPrice,
            eventData.sponsor
          ));
          return allEvents;
      },
      error: err => {
        console.log('Blad pobrania wydarzeń ', err);
      }
    });
    return null;
  }
}
