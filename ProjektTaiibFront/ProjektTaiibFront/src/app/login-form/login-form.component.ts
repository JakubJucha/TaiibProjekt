import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent {
 form: FormGroup;

 constructor(formBuilder: FormBuilder,
             private userService: UserService,
             private router: Router,
             private _toastService: ToastrService) {
  this.form = formBuilder.group({
    username: formBuilder.control(null,[Validators.required]),
    password: formBuilder.control(null, [Validators.required])
  });
 }

 logIn() {
  const credentials = this.form.value;
  console.log(this.form.value);
  this.userService.login(credentials).subscribe(
      response => {
          if (response && response.token) {
              localStorage.setItem('token', response.token); 
              this.router.navigate(['/mainPage']);
              this._toastService.success("Pomyślnie zalogowano!")
              
          } else {
              console.error('Nie otrzymano tokena!');
              this._toastService.error("Błąd podczas logowania!")
          }
      },
      error => {
        this._toastService.error(error.error, "Błąd podczas logowania");
          console.error('Błąd podczas logowania');

      }
  );
}

back() {
  console.log('guzik co nic nie robi lmao')
}
 
}
