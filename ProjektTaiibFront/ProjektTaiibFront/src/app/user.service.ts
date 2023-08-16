import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = 'http://localhost:5168';

  constructor(private http: HttpClient) { }

  register(userData: any): Observable<any> {
    console.log(userData)
    return this.http.post(`${this.apiUrl}/api/authorize/register`, userData);
  }

  login(credentials: any): Observable<{ token: string }> {
    console.log(credentials)
    return this.http.post<{ token: string }>(`${this.apiUrl}/api/authorize/login`, credentials);
  }

 
}