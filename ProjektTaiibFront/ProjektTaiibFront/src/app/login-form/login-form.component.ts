import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent {
 form: FormGroup;

 constructor(formBuilder: FormBuilder, private userService: UserService,private router: Router) {
  this.form = formBuilder.group({
    username: formBuilder.control(null,[Validators.required]),
    password: formBuilder.control(null, [Validators.required])
  });
 }

 logIn() {
  const credentials = this.form.value; // Pobieramy wartości z formularza
  console.log(this.form.value);
  this.userService.login(credentials).subscribe(
      response => {
          if (response && response.token) {
              localStorage.setItem('token', response.token); 
              this.router.navigate(['/mainPage']);
              
          } else {

              console.error('Nie otrzymano tokena!');
          }
      },
      error => {
          
          console.error('Błąd podczas logowania:', error);

      }
  );
}
 
}
