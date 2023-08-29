import { Component, OnInit } from '@angular/core';
import { Events } from '../models/event';
import { EventsService } from '../events.service';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {
  newestEvents: Events[] = []

  constructor(private _eventsService: EventsService,
    private _fb: FormBuilder){}

  ngOnInit() {
    this._eventsService.getNewestEvents().subscribe({
      next: res => {
        this.newestEvents = res;
      },
      error: err => {
        console.log('Błąd pobierania wydarzeń.')
      }
    })
  }
}
