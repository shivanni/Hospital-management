import { Component } from '@angular/core';
import { PatientModel } from "src/app/PatientAddDetails/HospitalManagement.model";
import { HttpClient } from "@angular/common/http";

@Component({
    selector: 'app-root',
    templateUrl: './SearchPatient.View.html',
   
  })
  export class SearchComponent {
    patientName:string="";
    private patientModels:PatientModel[]=[]; 
    constructor(public http:HttpClient){
      
    }
    Search(){
      this.http.get("https://localhost:44372/api/PatientAPI?patientName=" +this.patientName)
      .subscribe(res=>this.Success(res),err=>this.Error(err));
    }
    Success(res){
      this.patientModels=res;
      this.patientName="";
    }
    Error(res){
      alert("Not found");
    }
  }
  