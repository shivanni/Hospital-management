import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PatientModel, PatientProblem } from './HospitalManagement.model'

import * as _ from 'lodash'
@Component({
  selector: 'app-root',
  templateUrl: './HospitalManagement.component.html',
})
export class HospitalManagementComponent {
  title = 'HospitalManagement';
  //patientProblemCollection:PatientProblem = new PatientProblem();
  patientProblem:PatientProblem = new PatientProblem();
  constructor(public Http: HttpClient) {
    this.patientObj = new PatientModel()  //single record
    
   
  }
  errorMsg = [];
  patientObj: PatientModel = null;
  patientList: Array<PatientModel> = new Array<PatientModel>();

  AddProblem(){
      this.patientObj.patientProblems.push(this.patientProblem);
      this.patientProblem = new PatientProblem();

  }

  Submit() {
    //var data = _.omit(this.patientObj, ['formPatientGroup']);
    var patientDto:any={};
    patientDto.name=this.patientObj.name;
     patientDto.problemDescription=this.patientObj.problemDescription;
    
    this.Http.post("https://localhost:44372/api/PatientAPI", patientDto)
      .subscribe(res => { this.Success(res) },
        err => { this.Error(err) }

      );
    // var patientDto:any={};
    // patientDto.name=this.patientObj.name;
    // patientDto.problemDescription=this.patientObj.problemDescription;
    // this.Http.post("https://localhost:44372/api/PatientAPI",
    // patientDto).subscribe(res=>this.Success(res),res=>this.Error(res));

    
  }
  Success(res) {
    this.patientList = res;
    this.patientObj = new PatientModel();
  }

  Error(res) {
    this.errorMsg = res;

  }
}


