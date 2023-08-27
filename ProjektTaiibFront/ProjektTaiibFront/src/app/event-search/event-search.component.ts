import { Component, OnInit } from '@angular/core';
import { EventsService } from '../events.service';
import { Events } from '../models/event';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-event-search',
  templateUrl: './event-search.component.html',
  styleUrls: ['./event-search.component.css']
})
export class EventSearchComponent implements OnInit {
allEvents: Events[] = []
filteredEvents: any[] = [];
filterForm: FormGroup;

uniqueLocations: Set<string> = new Set();
uniqueCategories: Set<string> = new Set();
uniqueSponsors: string[] = [];

selectedLocation: string = '';
selectedDate: string = '';
selectedCategory: string = '';
selectedSponsor: string = '';



constructor(private _eventsService: EventsService,
            private _fb: FormBuilder){
this.filterForm = this._fb.group({
  location: this._fb.control(null),
  date: this._fb.control(null),
  category: this._fb.control(null),
  sponsors: this._fb.control(null)
  
})
}

ngOnInit() {
  this._eventsService.getAllEvents().subscribe({
    next: res => {
      this.allEvents = res;
      this.filteredEvents = this.allEvents;
      console.log(res);
      this.allEvents.forEach(event => {
        if (event.location) {
          this.uniqueLocations.add(event.location);
        }

        if (event.category) {
          this.uniqueCategories.add(event.category);
        }

        this.generateUniqueSponsorsList();
      });
    },
    error: err => {
      console.log('Błąd pobierania wydarzeń.')
    }
  })
}

applyFilters() {
  this.filteredEvents = this.allEvents.filter(event => {
    const locationMatches = this.selectedLocation === '' || event.location === this.selectedLocation;
    let dateMatches;
    if ( event.date) {
       dateMatches = this.selectedDate === '' || this.compareDates(event.date, this.selectedDate);
    }
    const categoryMatches = this.selectedCategory === '' || event.category === this.selectedCategory;
    let sponsorMatches;
    if(event.sponsors) {
      sponsorMatches = this.selectedSponsor === '' || event.sponsors.includes(this.selectedSponsor);
    }
    

    return locationMatches && dateMatches && categoryMatches && sponsorMatches;
});
}

compareDates(eventDate: string, selectedDate: string): boolean {
  const eventDateOnly = new Date(eventDate).toISOString().split('T')[0];
  const selectedDateOnly = new Date(selectedDate).toISOString().split('T')[0]; 

  return eventDateOnly === selectedDateOnly; 
}

generateUniqueSponsorsList() {
  const sponsorsSet = new Set<string>(); 

  this.allEvents.forEach(event => {
    if (event.sponsors) {
      event.sponsors.forEach(sponsor => {
        sponsorsSet.add(sponsor);
    });
    }
  });

  this.uniqueSponsors = Array.from(sponsorsSet.values());
}

}
