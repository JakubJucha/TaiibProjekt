import { HttpClient } from '@angular/common/http';
import { AfterContentChecked, Component, OnChanges } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import {Payment} from 'src/app/enums/payment'
@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements AfterContentChecked {
  form: FormGroup
  isChecked: boolean = false;
  selectedPayment: Payment = Payment.BLIK; // Wybrana opcja
  paymentOptions = Object.values(Payment); // Tablica z opcjami
  
  constructor(private http: HttpClient,
              formBuilder: FormBuilder,
              private router: Router,
              private _toastrService: ToastrService) {

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
      return null; 
    }
    
    let pass = passControl.value;
    let confirmPass = confirmPassControl.value;
  
    return pass === confirmPass ? null : { notSame: true };
  }
  
  showAdditionalInfo() {
    this.isChecked = !this.isChecked;
    if (!this.isChecked) {
     this.form.get('name')?.setValue(null);
     this.form.get('surname')?.setValue(null);
     this.form.get('phoneNumber')?.setValue(null);
     this.form.get('country')?.setValue(null);
     this.form.get('zipCode')?.setValue(null);
     this.form.get('city')?.setValue(null);
     this.form.get('street')?.setValue(null);
     this.form.get('houseNumber')?.setValue(null);
     this.form.get('localNumber')?.setValue(null);
     this.form.get('additionalInformation')?.setValue(null);
    }
  }

  isValid(name: string) : boolean {
    return this.form.controls[name].valid || !this.form.controls[name].dirty;
  }

  register() {
    const formData = this.form.value;
    console.log(formData);
    this.http.post('http://localhost:5168/api/authorize/register', formData).subscribe(
        response => {
            console.log('Rejestracja zakończona pomyślnie!', response);
            this._toastrService.success("Pomyślnie utworzono konto");

        },
        error => {
            console.error('Błąd podczas rejestracji:', error);
            this._toastrService.error(error.error, "Błąd podczas rejestracji.")
        }
    );
  }




}
