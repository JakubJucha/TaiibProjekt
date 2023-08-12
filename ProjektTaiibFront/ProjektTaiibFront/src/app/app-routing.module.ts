import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginRegisterComponent } from './login-register/login-register.component';
import { MainPageComponent } from './main-page/main-page.component';
import { EventDetailsComponent } from './event-details/event-details.component';
import { EventBuyTicketComponent } from './event-buy-ticket/event-buy-ticket.component';

const routes: Routes = [
  { path: 'login', component: LoginRegisterComponent },
  { path: 'mainPage', component: MainPageComponent },
  { path: 'mainPage/eventDetails', component: EventDetailsComponent }, 
  { path: 'mainPage/eventDetails/buyTicket', component: EventBuyTicketComponent }, 
  { path: '', redirectTo: 'mainPage', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
