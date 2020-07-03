//import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";

import { HttpClientModule } from "@angular/common/http";
//import {Sroutes} from "src/app/Routing/SearchRouting"
import { CommonModule } from '@angular/common';
import { PatientLoginComponent } from './PatientLogin.component';
import { Lroutes } from '../Routing/LogIn';



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
  providers: [],
  bootstrap: [PatientLoginComponent]
})
export class LoginhModule { }
