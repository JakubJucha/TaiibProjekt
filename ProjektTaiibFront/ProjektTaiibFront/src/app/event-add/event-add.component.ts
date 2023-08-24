import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {MatDatepickerModule} from '@angular/material/datepicker';

@Component({
  selector: 'app-event-add',
  templateUrl: './event-add.component.html',
  styleUrls: ['./event-add.component.css']
})
export class EventAddComponent {
addEventForm: FormGroup;

constructor(private _fb: FormBuilder,
            private http: HttpClient) {
this.addEventForm = this._fb.group({
  eventName: this._fb.control(null,[Validators.required]),
  location: this._fb.control(null,[Validators.required]),
  date: this._fb.control(null,[Validators.required]),
  description: this._fb.control(null,[Validators.required]),
  category: this._fb.control(null,[Validators.required]),
  amountTickt: this._fb.control(null,[Validators.required,]),
  ticketPrice: this._fb.control(null,[Validators.required,]),
  sponsor: this._fb.control(null,[Validators.required]),
});
}

addEvent() {
  const formData = this.addEventForm.value;
  console.log(formData);
  this.http.post('http://localhost:5168/api/event', formData).subscribe(
      response => {
          console.log('Dodano nowe wydarzenie!', response);
          this.addEventForm.reset();
      },
      error => {
          console.error('Błąd dodawania wydarzenia!:', error);
      
      }
  );
}



}
