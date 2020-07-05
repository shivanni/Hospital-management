//import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { CommonModule } from '@angular/common';
import { PatientLoginComponent } from './PatientLogin.component';
import { Lroutes } from '../Routing/LogIn';
import { User } from './PatientLogin.Model';
import { SecurityLogic } from '../Utilities/Utility.AuthGuard';
import { MyJwtInterceptor } from '../Utilities/Token.Interceptor';

@NgModule({
  declarations: [
   
    PatientLoginComponent
    
  ],
  imports: [
   CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forChild(Lroutes),
   
  ],
  providers: [SecurityLogic, { 
    provide: HTTP_INTERCEPTORS, 
    useClass: MyJwtInterceptor, 
    multi: true }],
  bootstrap: [PatientLoginComponent]
})
export class LoginhModule { }
