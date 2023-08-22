import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Payment } from '../enums/payment';

@Component({
  selector: 'app-user-data',
  templateUrl: './user-data.component.html',
  styleUrls: ['./user-data.component.css']
})
export class UserDataComponent implements OnInit {
  detailedInfo: any;
  form: FormGroup;
  paymentOptions = Object.values(Payment);

  private _userId = null;

  constructor(private http: HttpClient,
     private _userService: UserService,
     private _formBuilder: FormBuilder,) { 

      this.form = _formBuilder.group({
        name: _formBuilder.control(this.detailedInfo?.name),
        surname: _formBuilder.control(this.detailedInfo?.surname),
        phoneNumber: _formBuilder.control(this.detailedInfo?.phoneNumber),
        country: _formBuilder.control(this.detailedInfo?.country),
        zipCode: _formBuilder.control(this.detailedInfo?.zipCode),
        city: _formBuilder.control(this.detailedInfo?.city),
        street: _formBuilder.control(this.detailedInfo?.street),
        houseNumber: _formBuilder.control(this.detailedInfo?.houseNumber),
        localNumber: _formBuilder.control(this.detailedInfo?.localNumber),
        payment: _formBuilder.control(this.detailedInfo?.payment),
        additionalInformation: _formBuilder.control(this.detailedInfo?.additionalInformation),
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

  updateUserData() {
    const formData = this.form.value;
    this.http.post(`http://localhost:5168/api/user/${this._userId}/update`, formData).subscribe(
        response => {
            console.log('Pomyślnie zmodyfikowano dane!', response);
        },
        error => {
            console.error('Błąd podczas nadpisywanai danych:', error);
        
        }
    );
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
        this._userId = this.detailedInfo.userId;

        this.form.setValue({
          name: this.detailedInfo.name,
          surname: this.detailedInfo.surname,
          phoneNumber: this.detailedInfo.phone,
          country: this.detailedInfo.country,
          zipCode: this.detailedInfo.zipCode,
          city: this.detailedInfo.city,
          street: this.detailedInfo.street,
          houseNumber: this.detailedInfo.houseNumber,
          localNumber: this.detailedInfo.localNumber,
          payment: this.detailedInfo.payment,
          additionalInformation: this.detailedInfo.additionalInformation,
        });
      },

      (error: any) => {
        console.error('Error:', error);
      }
    );
  }
}