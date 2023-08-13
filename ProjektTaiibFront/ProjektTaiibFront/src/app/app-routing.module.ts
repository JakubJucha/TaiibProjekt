import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginRegisterComponent } from './login-register/login-register.component';
import { MainPageComponent } from './main-page/main-page.component';
import { EventDetailsComponent } from './event-details/event-details.component';
import { EventBuyTicketComponent } from './event-buy-ticket/event-buy-ticket.component';
import { EventSearchComponent } from './event-search/event-search.component';
import { UserMenuComponent } from './user-menu/user-menu.component';
import { UserDataComponent } from './user-data/user-data.component';
import { UserTicketsComponent } from './user-tickets/user-tickets.component';
import { UserOptionsComponent } from './user-options/user-options.component';
import { EventAddComponent } from './event-add/event-add.component';

const routes: Routes = [
  { path: 'login', component: LoginRegisterComponent },
  { path: 'mainPage', component: MainPageComponent },
  { path: 'mainPage/eventDetails', component: EventDetailsComponent }, 
  { path: 'mainPage/eventDetails/buyTicket', component: EventBuyTicketComponent }, 
  { path: 'eventSearch', component: EventSearchComponent},
  { path: 'addEvent', component: EventAddComponent},
  { path: 'userMenu', component: UserMenuComponent,
  children: [
    {path:'userData', component: UserDataComponent},
    {path:'userTickets', component: UserTicketsComponent},
    {path: 'userOptions', component:UserOptionsComponent}
  ]},
  { path: '', redirectTo: 'mainPage', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
