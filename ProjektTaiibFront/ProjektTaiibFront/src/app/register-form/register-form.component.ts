import { HttpClient } from '@angular/common/http';
import { AfterContentChecked, Component, OnChanges } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements AfterContentChecked {
  form: FormGroup
  isChecked: boolean = false;
  
  constructor(formBuilder: FormBuilder) {

    this.form = formBuilder.group({
      email: formBuilder.control(null, [Validators.required, Validators.email]),
      loginRegister: formBuilder.control(null, [Validators.required]),
      passwordRegister: formBuilder.control(null, [Validators.required, Validators.pattern(/^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$/)]),
      repeatPassword: formBuilder.control(null, [Validators.required]),
      name: formBuilder.control(null),
      surname: formBuilder.control(null),
      phoneNumber: formBuilder.control(null, [Validators.pattern(/^[0-9]{9}$/)]),
      country: formBuilder.control(null),
      zipCode: formBuilder.control(null,[Validators.pattern(/^\d{2}-\d{3}$/)]),
      city: formBuilder.control(null),
      street: formBuilder.control(null),
      houseNumber: formBuilder.control(null),
      localNumber: formBuilder.control(null),
      payment: formBuilder.control(null),
      additionalInformation: formBuilder.control(null),
    }, {
    });
    
  }
  
  ngAfterContentChecked(): void {
    console.log('asd')
    this.isPasswordConfirmed();
  }

  isPasswordConfirmed() {
    let password = this.form.controls['passwordRegister'].value;
    let repeatPassword = this.form.controls['repeatPassword'].value;
    if ( password === repeatPassword) {
      this.form.controls['repeatPassword'].setErrors(null);
    } else {
      const customError = { customErrorKey: true };
      this.form.controls['repeatPassword'].setErrors(customError);
    }
  }

  checkPasswords: ValidatorFn = (group: AbstractControl):  ValidationErrors | null => { 
    let passControl = group.get('passwordRegister');
    let confirmPassControl = group.get('repeatPassword');
    
    if (!passControl || !confirmPassControl) {
      return null;  // Jeśli któryś z kontroli nie istnieje, zwróć null
    }
    
    let pass = passControl.value;
    let confirmPass = confirmPassControl.value;
  
    return pass === confirmPass ? null : { notSame: true };
  }
  showAdditionalInfo() {
    this.isChecked = !this.isChecked;
  }

  isValid(name: string) : boolean {
    return this.form.controls[name].valid || !this.form.controls[name].dirty;
  }

  register() {
    //this._httpClient.post()
  }




}
