//import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import { HospitalManagementComponent } from './HospitalManagement.component';
//import { routes } from '../Routing/MainRouting';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http"
import {Proutes} from "../Routing/PatientInfoRouting"
import { CommonModule } from '@angular/common';
import { MyJwtInterceptor } from '../Utilities/Token.Interceptor';
//import { SecurityLogic } from '../Utilities/Utility.AuthGuard';


@NgModule({
  declarations: [
   
   HospitalManagementComponent,
  
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forChild(Proutes),

   
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, 
      useClass: MyJwtInterceptor, 
      multi: true } 
  ],
  bootstrap: [HospitalManagementComponent]
})
export class PatientModule { }
