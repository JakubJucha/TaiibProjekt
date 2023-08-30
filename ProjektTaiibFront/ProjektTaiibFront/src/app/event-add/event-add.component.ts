import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-event-add',
  templateUrl: './event-add.component.html',
  styleUrls: ['./event-add.component.css']
})
export class EventAddComponent {
addEventForm: FormGroup;

constructor(private _fb: FormBuilder,
            private http: HttpClient,
            private _toastrService: ToastrService) {
this.addEventForm = this._fb.group({
  eventName: this._fb.control(null,[Validators.required]),
  location: this._fb.control(null,[Validators.required]),
  date: this._fb.control(null,[Validators.required]),
  description: this._fb.control(null,[Validators.required]),
  category: this._fb.control(null,[Validators.required]),
  amountTicket: this._fb.control(null,[Validators.required, Validators.pattern(/^[0-9]+$/)]),
  ticketPrice: this._fb.control(null,[Validators.required, Validators.pattern(/^\d+(\.\d{2})?$/)]),
  sponsors: this._fb.control(null,[Validators.required]),
});
}

addEvent() {
  const formData = this.addEventForm.value;
  console.log(formData);
  this.http.post('http://localhost:5168/api/event/add', formData).subscribe(
      response => {
          console.log('Dodano nowe wydarzenie!', response);
          this._toastrService.success("Pomyślnie dodano nowe wydarzenie!")
          this.addEventForm.reset();
      },
      error => {
          console.error('Błąd dodawania wydarzenia!:', error);
          this._toastrService.error(error.error, "Błąd podczas dodawania wydarzenia!")
      }
  );
}

isValid(name: string) : boolean {
  return this.addEventForm.controls[name].valid || !this.addEventForm.controls[name].dirty;
}


}
