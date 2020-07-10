
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import { HospitalManagementComponent } from './HospitalManagement.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http"
import { CommonModule } from '@angular/common';
import { MyJwtInterceptor } from '../Utilities/Token.Interceptor';
import { Proutes } from '../Routing/PatientAddRouting';



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
