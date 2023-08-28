import { Component, OnInit } from '@angular/core';
import { Events } from '../models/event';
import { ActivatedRoute } from '@angular/router';
import { EventsService } from '../events.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../user.service';
import { HttpClient } from '@angular/common/http';
import { Payment } from '../enums/payment';

@Component({
  selector: 'app-event-buy-ticket',
  templateUrl: './event-buy-ticket.component.html',
  styleUrls: ['./event-buy-ticket.component.css']
})
export class EventBuyTicketComponent implements OnInit {

  currentEvent: Events = new Events();
  userInfoForm: FormGroup;
  ticketForm: FormGroup;
  detailedInfo: any;
  paymentOptions = Object.values(Payment);
  chosenPayment: string = '';
  private _userId = null;

  areTicketsCorrect: boolean = false;

  blikValue: string = '';
  cardValue: string = '';
  ccvValue: string = '';
  isButtonDisabled: boolean = true;

  normalTicketValue: number = 0;
  normalPremiumTicketValue: number = 0;
  reducedTicketValue: number = 0;
  reducedPremiumTicketValue: number = 0;

  normalticketsPrice: number = 0;
  reducedTicketPrice: number = 0;
  michal: number = 0;

  constructor(private _route: ActivatedRoute,
              private _eventsService: EventsService,
              private _formBuilder: FormBuilder,
              private _userService: UserService,
              private http: HttpClient,){
                this.userInfoForm = _formBuilder.group({
                  name: _formBuilder.control(this.detailedInfo?.name, [Validators.required]),
                  surname: _formBuilder.control(this.detailedInfo?.surname, [Validators.required]),
                  phoneNumber: _formBuilder.control(this.detailedInfo?.phoneNumber, [Validators.required, Validators.pattern(/^[0-9]{9}$/)]),
                  country: _formBuilder.control(this.detailedInfo?.country, [Validators.required]),
                  zipCode: _formBuilder.control(this.detailedInfo?.zipCode, [Validators.required, Validators.pattern(/^\d{2}-\d{3}$/)]),
                  city: _formBuilder.control(this.detailedInfo?.city, [Validators.required]),
                  street: _formBuilder.control(this.detailedInfo?.street, [Validators.required]),
                  houseNumber: _formBuilder.control(this.detailedInfo?.houseNumber, [Validators.required]),
                  localNumber: _formBuilder.control(this.detailedInfo?.localNumber),
                  payment: _formBuilder.control(this.detailedInfo?.payment, [Validators.required]),
                  additionalInformation: _formBuilder.control(this.detailedInfo?.additionalInformation),
                  blik: _formBuilder.control(null, [Validators.pattern(/^\d{6}$/)]),
                  card: _formBuilder.control(null, [Validators.pattern(/^\d{4}[-\s]?\d{4}[-\s]?\d{4}[-\s]?\d{4}$/)]),
                  ccv: _formBuilder.control(null, [Validators.pattern(/^\d{3,4}$/)])
                });

              this.ticketForm = this._formBuilder.group({
                normalTicket: this._formBuilder.control(null, [Validators.pattern(/^[1-9][0-9]*$/)]),
                normalPremiumTicket: this._formBuilder.control(null, [Validators.pattern(/^[1-9][0-9]*$/)]),
                reducedTicket: this._formBuilder.control(null, [Validators.pattern(/^[1-9][0-9]*$/)]),
                reducedPremiumTicket: this._formBuilder.control(null, [Validators.pattern(/^[1-9][0-9]*$/)])
              });

  }

  ngOnInit(): void {
    this.checkTickets();
    this.checkButtonAvailability();
    this._route.paramMap.subscribe(params => {
      const eventIdParam = params.get('eventId');
      
      if (eventIdParam !== null) {
        const eventId = +eventIdParam;
        if (!isNaN(eventId)) {
          this._eventsService.getEventById(eventId).subscribe({
            next: res => {
              this.currentEvent = res;
            },
            error: err => {
              console.log('Błąd pobierania wydarzenia.');
            }
          })
        } else {
          console.error('Invalid eventId parameter');
        }
      } else {
        console.error('eventId parameter is missing');
      }
    });

    const token = localStorage.getItem('token');
    if (token) {
      const tokenPayload = this._userService.getDecodedToken(token);
      const username = tokenPayload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
    
    this.getDetailedInformation(username); 
    }

  }

  checkTickets(){
    if (this.currentEvent.amountTicket) {
      if ((Number(this.normalTicketValue) + Number(this.reducedTicketValue)) <= parseInt(this.currentEvent.amountTicket) && (this.normalTicketValue + this.reducedTicketValue) > 0.01)  {
        if (this.normalPremiumTicketValue <= this.normalTicketValue && this.reducedPremiumTicketValue <= this.reducedTicketValue) {
          this.areTicketsCorrect = true;
        } else {
          this.areTicketsCorrect = false;
        }
      } else {
        this.areTicketsCorrect = false;
      }
    }

    const regularPrice = this.currentEvent.ticketPrice;
    const premiumNormalPrice = Number(regularPrice) * 2;

    this.normalticketsPrice = Number(this.normalPremiumTicketValue) * Number(premiumNormalPrice) + ((Number(this.normalTicketValue) - Number(this.normalPremiumTicketValue)) * Number(regularPrice));
    if ( Number.isNaN(this.normalticketsPrice)) {
      this.normalticketsPrice = 0;
    }

    const reducedPrice = Number(regularPrice) / 2;
    const reducedPremiumPrice = Number(reducedPrice) * 2;

    this.reducedTicketPrice = Number(this.reducedPremiumTicketValue) * Number(reducedPremiumPrice) +((Number(this.reducedTicketValue) - Number(this.reducedPremiumTicketValue)) * Number(reducedPrice));
    if ( Number.isNaN(this.reducedTicketPrice)) {
      this.reducedTicketPrice = 0;
    }

    this.michal = Number(this.reducedTicketPrice) + Number(this.normalticketsPrice);
    if ( Number.isNaN(this.michal)) {
      this.michal = 0;
    }
  }

  buyTicket() {
    const userId = this._userId;
    const eventId = this.currentEvent.id;
    const formdata = this.ticketForm.value;
    const ticketPrice = this.currentEvent.ticketPrice;
    const requestData = {
    ticketPrice: ticketPrice,
    ticketInfo: formdata
  };
    const apiUrl = `http://localhost:5168/api/ticket/${eventId}/${userId}/buy`;
    this.http.post(apiUrl, requestData).subscribe({
      next: res => {
        console.log('Pomyślnie kupiono bilet');
      },
      error: err => {
        console.log('Błąd podczas kupowania.');
      }
    })

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

        this.userInfoForm.setValue({
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
          blik: null,
          card: null,
          ccv: null,
        });
      },

      (error: any) => {
        console.error('Error:', error);
      }
    );
  }

  onBlikChange() {
    this.checkButtonAvailability();
  }

  onCardChange() {
    this.checkButtonAvailability();
  }

  private checkButtonAvailability() {
    if (this.blikValue === '' && (this.cardValue != '' && this.ccvValue != '')) {
      this.isButtonDisabled = false;
    }  else if (this.blikValue != '' && (this.cardValue === '' && this.ccvValue === '')) {
      this.isButtonDisabled = false;
    } else {
      this.isButtonDisabled = true;
  }
  }

}
