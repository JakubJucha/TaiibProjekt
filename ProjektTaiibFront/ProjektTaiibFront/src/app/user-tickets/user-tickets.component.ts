import { Component, OnInit } from '@angular/core';
import { TicketsService } from '../tickets.service';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-tickets',
  templateUrl: './user-tickets.component.html',
  styleUrls: ['./user-tickets.component.css']
})
export class UserTicketsComponent implements OnInit {

  ticketsData: any[] = [];

  constructor(private _ticketsService: TicketsService,
              private _userService: UserService){

  }

  ngOnInit(): void {
    this._readData();
  }


  private _readData() {
    this._ticketsService.getAllTickets(this._userService.getUserId()).subscribe({
      next: data => {
          this.ticketsData = data;
      },
      error: err => {
        console.log('Błąd podczas pobierania biletów ', err);
      }
    })
  }


}
