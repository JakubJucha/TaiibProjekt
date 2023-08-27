import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Events} from './models/event'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventsService {
  

  constructor(private _http: HttpClient,) { }

  getAllEvents(): Observable<Events[]> {
    const apiUrl = `http://localhost:5168/api/event/getAll`;
    return this._http.get<Events[]>(apiUrl);
  }

  getNewestEvents(): Observable<Events[]> {
    const apiUrl = `http://localhost:5168/api/event/getNewest`;
    return this._http.get<Events[]>(apiUrl);
  }

  getEventById(eventId: number): Observable<Events> {
    const apiUrl = `http://localhost:5168/api/event/${eventId}`;
    return this._http.get<Events>(apiUrl);
  }


}
