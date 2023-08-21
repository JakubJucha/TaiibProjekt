import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-data',
  templateUrl: './user-data.component.html',
  styleUrls: ['./user-data.component.css']
})
export class UserDataComponent implements OnInit {

  constructor(private http: HttpClient, private _userService: UserService) { }
  detailedInfo: any;
  ngOnInit(): void {
    const token = localStorage.getItem('token');
    
    if (token) {
      const tokenPayload = this._userService.getDecodedToken(token);
      const username = tokenPayload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
    
    this.getDetailedInformation(username); 
  }
  }
  getDetailedInformation(username: string): void {
    const apiUrl = `http://localhost:5168/api/user/detailed-information/${username}`;
    const token = localStorage.getItem('token'); 
    
    const headers = {
      Authorization: `${token}` 
    };
    
    this.http.get(apiUrl, { headers }).subscribe(
      (response: any) => {
        this.detailedInfo = response;
  
        // Tutaj możesz wyświetlić dane na konsoli lub zrobić z nimi coś innego
        console.log('Detailed Info:', this.detailedInfo);
  
        // Przykład wypisania "Name" na konsoli
        console.log('Name:', this.detailedInfo.name);
      },
      (error: any) => {
        console.error('Error:', error);
      }
    );
  }
}