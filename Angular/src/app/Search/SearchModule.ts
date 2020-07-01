//import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
//import { HospitalManagementComponent } from '../PatientInfo/HospitalManagement.component';
//import { routes } from '../Routing/MainRouting';
import { HttpClientModule } from "@angular/common/http";
import { SearchComponent } from "src/app/Search/SearchPatient.Component";
import {Sroutes} from "src/app/Routing/SearchRouting"
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [
   
    SearchComponent
    
    
  ],
  imports: [
   CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forChild(Sroutes),

   
  ],
  providers: [],
  bootstrap: [SearchComponent]
})
export class SearchModule { }
