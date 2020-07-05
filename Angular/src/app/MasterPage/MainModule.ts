import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import { MasterComponent } from "./MasterComponent";
import { routes } from '../Routing/MainRouting';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { HomeComponent } from './HomeComponent';
import { User } from '../PatientLogin/PatientLogin.Model';
import { SecurityLogic } from '../Utilities/Utility.AuthGuard';
import { MyJwtInterceptor } from '../Utilities/Token.Interceptor';

@NgModule({
  declarations: [
   
    HomeComponent,
    MasterComponent,
  
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes),

   
  ],
  providers: [User, SecurityLogic,
    { 
      provide: HTTP_INTERCEPTORS, 
      useClass: MyJwtInterceptor, 
      multi: true } ],
  bootstrap: [MasterComponent]
})
export class MainModule { }
