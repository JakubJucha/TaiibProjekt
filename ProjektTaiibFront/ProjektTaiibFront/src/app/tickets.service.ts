import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TicketsService {

  constructor(private _http: HttpClient,) { }


  getAllTickets(userId: number | null): Observable<any> {
    const apiUrl = `http://localhost:5168/api/ticket/${userId}`;
    return this._http.get<any>(apiUrl);
  }




}
