import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent {
 form: FormGroup;

 constructor(formBuilder: FormBuilder) {
  this.form = formBuilder.group({
    login: formBuilder.control(null,[Validators.required]),
    password: formBuilder.control(null, [Validators.required])
  });
 }

 logIn() {
  
 }
 
}
