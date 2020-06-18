import { Component } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {PatientModel} from './HospitalManagement.model'

import * as _ from 'lodash' 
@Component({
  selector: 'app-root',
  templateUrl: './HospitalManagement.component.html',
})
export class HospitalManagementComponent {
  title = 'HospitalManagement';
  constructor(public Http:HttpClient){
    this.patientObj=new PatientModel()
  }
  errorMsg=[];
  patientObj:PatientModel= null;
  patientList:Array<PatientModel>=new Array<PatientModel>();
  

   Submit(){
    var data = _.omit(this.patientObj, ['formPatientGroup']);
          this.Http.post("https://localhost:44372/Patient/Submit",data)
              .subscribe(
                res=>this.Success(res),
                res=>this.Error(res)
            );

   }
  Success(res){
    this.patientList=res;
    this.patientObj=new PatientModel();
  }
   
   Error(res){
    this.errorMsg=res;
    
   }
}
