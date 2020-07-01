//import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import { HospitalManagementComponent } from './HospitalManagement.component';
//import { routes } from '../Routing/MainRouting';
import { HttpClientModule } from "@angular/common/http"
import {Proutes} from "../Routing/PatientInfoRouting"
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
   
   HospitalManagementComponent
  
    
    
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forChild(Proutes),

   
  ],
  providers: [],
  bootstrap: [HospitalManagementComponent]
})
export class PatientModule { }
