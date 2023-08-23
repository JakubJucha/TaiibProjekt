import { HttpClient } from '@angular/common/http';
import { AfterContentChecked, Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { Form, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-user-options',
  templateUrl: './user-options.component.html',
  styleUrls: ['./user-options.component.css']
})
export class UserOptionsComponent implements OnInit, AfterContentChecked {
  isChangeLogin: boolean = false;
  isChangePassword: boolean = false;
  isChangeEmail: boolean = false;
  detailedInfo: any;
  userLogin: string = '';
  userEmail: string ='';

  formLogin: FormGroup;
  formPassword: FormGroup;
  formEmail: FormGroup;

  constructor(private _http: HttpClient,
    private _userService: UserService,
    private _fb: FormBuilder) {

      this.formLogin = _fb.group({
        newLogin: _fb.control(null),
      });
      this.formPassword = _fb.group({
        currentPassword: _fb.control(null),
        newPassword: _fb.control(null),
        repeatNewPassword: _fb.control(null),
      });
      this.formEmail = _fb.group({
        newEmail: _fb.control(null),
        repeatNewEmail: _fb.control(null),
      });

  }

  ngOnInit(): void {
    const token = localStorage.getItem('token');
    if (token) {
      const tokenPayload = this._userService.getDecodedToken(token);
      const username = tokenPayload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
    
    this.getDetailedInformation(username); 
    }
  }

  ngAfterContentChecked(): void {
    this.isPasswordConfirmed();
  }

  isPasswordConfirmed() {
    let password = this.formPassword.controls['newPassword'].value;
    let repeatPassword = this.formPassword.controls['repeatNewPassword'].value;
    if ( password === repeatPassword) {
      this.formPassword.controls['repeatNewPassword'].setErrors(null);
    } else {
      const customError = { customErrorKey: true };
      this.formPassword.controls['repeatNewPassword'].setErrors(customError);
    }
  }

  changeToNewLogin() {
    const formData = this.formLogin.value;
    this._http.post(`http://localhost:5168/api/user/${this._userService.getUserId()}/update`, formData).subscribe(
        response => {
            console.log('Pomyślnie zmodyfikowano login!', response);
        },
        error => {
            console.error('Błąd podczas nadpisywania loginu:', error);
        
        }
    );
  }

  changeToNewEmail() {
    const formData = this.formEmail.value;
    let email = this.formEmail.controls['newEmail'].value;
    let repeatEmail= this.formEmail.controls['repeatNewEmail'].value;
    if ( email === repeatEmail) {
      this._http.post(`http://localhost:5168/api/user/${this._userService.getUserId()}/update`, formData).subscribe(
        response => {
            console.log('Pomyślnie zmodyfikowano email!', response);
        },
        error => {
            console.error('Błąd podczas nadpisywania emaila:', error);
        
        }
    );
    } else {
      console.log('Emaile nie sa takie same');
    }
  }

  changeToNewPassword() {
    const formData = this.formPassword.value;
    let password = this.formPassword.controls['newPassword'].value;
    let repeatPassword = this.formPassword.controls['repeatNewPassword'].value;
    if ( password === repeatPassword) {
      this._http.post(`http://localhost:5168/api/user/${this._userService.getUserId()}/update`, formData).subscribe(
        response => {
            console.log('Pomyślnie zmodyfikowano hasła!', response);
        },
        error => {
            console.error('Błąd podczas nadpisywania hasła:', error);
        
        }
    );
    } else {
      console.log('Hasla nie sa takie same');
    }
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
