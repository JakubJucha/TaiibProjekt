import { Component,Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ticket-showcase',
  templateUrl: './ticket-showcase.component.html',
  styleUrls: ['./ticket-showcase.component.css']
})
export class TicketShowcaseComponent {

  @Input() ticketData: any;

  constructor(private _router: Router) {}

  navigateToEvent(eventId: number) {
    this._router.navigate(['event', eventId]);
  }

}
