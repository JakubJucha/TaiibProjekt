import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './navbar/navbar.component'
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatButtonModule} from '@angular/material/button'
import {MatIconModule} from '@angular/material/icon'
import { ReactiveFormsModule } from '@angular/forms';
import { LoginFormComponent } from './login-form/login-form.component';
import { RegisterFormComponent } from './register-form/register-form.component';
import { LoginRegisterComponent } from './login-register/login-register.component';
import { RouterModule } from '@angular/router';
import { MainPageComponent } from './main-page/main-page.component';
import { EventShowcaseComponent } from './event-showcase/event-showcase.component';
import { FooterComponent } from './footer/footer.component';
import { EventDetailsComponent } from './event-details/event-details.component';
import { EventBuyTicketComponent } from './event-buy-ticket/event-buy-ticket.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { EventSearchComponent } from './event-search/event-search.component';
import { UserMenuComponent } from './user-menu/user-menu.component';
import { UserDataComponent } from './user-data/user-data.component';
import { UserTicketsComponent } from './user-tickets/user-tickets.component';
import { UserOptionsComponent } from './user-options/user-options.component';
import { TicketShowcaseComponent } from './ticket-showcase/ticket-showcase.component';
import { EventAddComponent } from './event-add/event-add.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LoginFormComponent,
    RegisterFormComponent,
    RegisterFormComponent,
    LoginRegisterComponent,
    MainPageComponent,
    EventShowcaseComponent,
    FooterComponent,
    EventDetailsComponent,
    EventBuyTicketComponent,
    EventSearchComponent,
    UserMenuComponent,
    UserDataComponent,
    UserTicketsComponent,
    UserOptionsComponent,
    TicketShowcaseComponent,
    EventAddComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    ReactiveFormsModule,
    MatTooltipModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
