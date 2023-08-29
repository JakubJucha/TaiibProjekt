import { Component, Input } from '@angular/core';
import { Events } from '../models/event';
import { Router } from '@angular/router';

@Component({
  selector: 'app-event-showcase',
  templateUrl: './event-showcase.component.html',
  styleUrls: ['./event-showcase.component.css']
})
export class EventShowcaseComponent {
  @Input() event: Events = new Events();

  constructor(private _router: Router){

  }


  navigateToEventDetails(eventId: number) {
    this._router.navigate(['event', eventId]);
  }

  isSoldOut(): boolean {
    if (Number(this.event.amountTicket) == 0) {
      return true;
    } else {
      return false;
    }
  }

  
}
