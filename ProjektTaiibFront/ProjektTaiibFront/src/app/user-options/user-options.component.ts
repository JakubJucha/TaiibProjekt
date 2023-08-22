import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-options',
  templateUrl: './user-options.component.html',
  styleUrls: ['./user-options.component.css']
})
export class UserOptionsComponent implements OnInit {
  isChangeLogin: boolean = false;
  isChangePassword: boolean = false;
  isChangeEmail: boolean = false;
  detailedInfo: any;
  userLogin: string = '';
  userEmail: string ='';

  constructor(private _http: HttpClient,
    private _userService: UserService) {

  }

  ngOnInit(): void {
    const token = localStorage.getItem('token');
    if (token) {
      const tokenPayload = this._userService.getDecodedToken(token);
      const username = tokenPayload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
    
    this.getDetailedInformation(username); 
    }
  }

  updateUserData() {

  }


  getDetailedInformation(username: string): void {
    const apiUrl = `http://localhost:5168/api/user/detailed-information/${username}`;
    const token = localStorage.getItem('token'); 
    
    const headers = {
      Authorization: `${token}` 
    };
    
    this._http.get(apiUrl, { headers }).subscribe(
      (response: any) => {
        this.detailedInfo = response;
        this.userLogin = this.detailedInfo.login;
        this.userEmail = this.detailedInfo.email;
      },

      (error: any) => {
        console.error('Error:', error);
      }
    );
  }


  changeLogin() {
    this.isChangeLogin = !this.isChangeLogin;
  }

  changePassword() {
    this.isChangePassword = !this.isChangePassword;
  }

  changeEmail() {
    this.isChangeEmail = !this.isChangeEmail;
  }

}
