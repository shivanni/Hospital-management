import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PatientModel, PatientProblem, Disease } from './HospitalManagement.model'

import * as _ from 'lodash'
import { DiseaseModel } from '../Disease/DModel';

@Component({
  selector: 'app-root',
  templateUrl: './HospitalManagement.component.html',


})
export class HospitalManagementComponent implements OnInit {

  public diseases: Array<DiseaseModel> = new Array<DiseaseModel>();
  ngOnInit() {

  }
  patientProblem: PatientProblem = new PatientProblem();
 //// gDiseaseObj: GDisease = new GDisease();
  constructor(public Http: HttpClient) {
    this.patientObj = new PatientModel()  //single record

    this.GetDisease();

  }
  errorMsg = [];
  patientObj: PatientModel = null;
  patientList: Array<PatientModel> = new Array<PatientModel>();

  AddProblem() {
    this.patientObj.patientProblems.push(this.patientProblem);
    this.patientProblem = new PatientProblem();

  }
  // AddDisease() {
  //   this.patientObj.gDiseaseObj.push(this.gDiseaseObj);
  //   this.gDiseaseObj = new GDisease();

  // }

  Submit() {
    //var data = _.omit(this.patientObj, ['formPatientGroup']);
    var patientDto: any = {};
    patientDto.name = this.patientObj.name;
    patientDto.diseaseName = this.patientObj.diseaseName;
    // patientDto.id = this.patientObj.id;
    patientDto.problems = []; //empty collection
    patientDto.problems = this.patientObj.patientProblems;
    patientDto.problemDescription = this.patientObj.problemDescription;
    patientDto.gDiseaseObj = [];
    //patientDto.gDiseaseObj=this.patientObj.gDiseaseObj;

    this.Http.post("https://localhost:44372/api/PatientAPI", patientDto)
      .subscribe(res => {
        this.Success(res)
      },
        err => {
          this.Error(err)
        }

      );
  }
  Success(res) {
  
    this.patientList = res;
    
    this.patientObj = new PatientModel();
  }

  Error(res) {
    this.errorMsg = res;

  }

  GetDisease() {

    this.Http.get<any>("https://localhost:44372/api/Disease")
      .subscribe(res => {

        this.diseases = res;
        // 
        console.log(res);
      },
        err => {
          console.log(err);     
        })

  }
  // select(){
 
  // }

}


