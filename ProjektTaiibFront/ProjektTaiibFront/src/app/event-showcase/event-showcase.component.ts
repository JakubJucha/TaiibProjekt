import { Component, Input } from '@angular/core';
import { Events } from '../models/event';

@Component({
  selector: 'app-event-showcase',
  templateUrl: './event-showcase.component.html',
  styleUrls: ['./event-showcase.component.css']
})
export class EventShowcaseComponent {
  @Input() event: Events = new Events();
}
