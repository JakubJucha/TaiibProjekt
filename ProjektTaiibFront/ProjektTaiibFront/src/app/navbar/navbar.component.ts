import { Component } from '@angular/core';
import { UserService } from '../user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

  constructor( private _userService: UserService){

  }

  get isLoggedIn() : boolean {
    const token = localStorage.getItem('token');
    console.log('token ',token)
    return token != null && token.length > 0;
  }

  logOut() {
    localStorage.removeItem('token');
  }

  get isAdmin() : boolean {
    const token = localStorage.getItem('token');
    if (token) {
      const tokenPayload = this._userService.getDecodedToken(token);
      return tokenPayload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] === 'admin';
    }
    return false;
  }

}
