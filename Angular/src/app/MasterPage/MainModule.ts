import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
//import { HospitalManagementComponent } from '../PatientInfo/HospitalManagement.component';
import { MasterComponent } from "./MasterComponent";
import { routes } from '../Routing/MainRouting';
import { HttpClientModule } from "@angular/common/http";
import { HomeComponent } from './HomeComponent';
//import { PatientLoginComponent } from '../PatientLogin/PatientLogin.component';



@NgModule({
  declarations: [
   
    HomeComponent,
    MasterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes),

   
  ],
  providers: [],
  bootstrap: [MasterComponent]
})
export class MainModule { }
