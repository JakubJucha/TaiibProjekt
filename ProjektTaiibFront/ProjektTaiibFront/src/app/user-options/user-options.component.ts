import { Component } from '@angular/core';

@Component({
  selector: 'app-user-options',
  templateUrl: './user-options.component.html',
  styleUrls: ['./user-options.component.css']
})
export class UserOptionsComponent {
  isChangeLogin: boolean = false;
  isChangePassword: boolean = false;
  isChangeEmail: boolean = false;

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
