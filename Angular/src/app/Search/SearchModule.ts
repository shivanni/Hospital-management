//import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { SearchComponent } from "src/app/Search/SearchPatient.Component";
import {Sroutes} from "src/app/Routing/SearchRouting"
import { CommonModule } from '@angular/common';
import {  MyJwtInterceptor } from '../Utilities/Token.Interceptor';



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
  providers: [
    {provide: HTTP_INTERCEPTORS, 
      useClass: MyJwtInterceptor, 
      multi: true }   ],
  bootstrap: [SearchComponent]
})
export class SearchModule { }
