import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginRegisterComponent } from './login-register/login-register.component';
import { MainPageComponent } from './main-page/main-page.component';

const routes: Routes = [
  {path: 'login', component: LoginRegisterComponent},
  {path: 'mainPage', component: MainPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
