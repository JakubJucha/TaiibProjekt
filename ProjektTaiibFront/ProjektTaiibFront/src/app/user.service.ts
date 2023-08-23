import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import jwtDecode from 'jwt-decode';

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

  getDecodedToken(token: string): any {
    try {
      return jwtDecode(token);
    } catch(error) {
      console.error('Błąd podczas dekodowania tokena: ', error);
      return null;
    }
  }

  getUserId(): number | null {
    const token = localStorage.getItem('token');
    let userId: number;
    if (token) {
      const tokenPayload = this.getDecodedToken(token);
      console.log('payload ',tokenPayload)
      userId = tokenPayload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
      console.log('userID: ', userId);
      return userId;
    }
    return null;
  }
 
}