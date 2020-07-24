import { Component } from '@angular/core';
import { PatientModel } from "src/app/PatientAddDetails/HospitalManagement.model";
import { HttpClient } from "@angular/common/http";
import { FormGroup, FormBuilder,FormArray,FormControl,ValidatorFn } from '@angular/forms';
import { of } from 'rxjs';
import { DiseaseModule } from './DiseaseModule';
import { DiseaseModel } from './DModel';

@Component({
    selector: 'app-root',
    templateUrl: './Disease.Component.html',
   
  })
  export class DiseaseComponent {

    public diseaseObj:DiseaseModel = new DiseaseModel();
    form: FormGroup;
    diseases = [];
    constructor(private formBuilder: FormBuilder, public http:HttpClient){
      this.form = this.formBuilder.group({
        diseases: ['']
      });
      // async orders
      of(this.getDiseases()).subscribe(orders =>{
        this.diseases = this.diseases;
        this.form.controls.orders.patchValue(this.diseases[0].id)
      });
    }
    getDiseases(){
    //   return[
    //     {id: 1, name:'None'},
    // {id: 2, name:'Blood-Pressure'},
    // {id: 3, name:'Diabetes'},
    // {id: 4, name:'Cystic Fibrosis'},
    // {id: 5, name:'Headache'},
    // {id: 6, name:'cold'},
    //   ]

    }

    Add(){
      console.log(this.form.value);

      this.http.post("https://localhost:44372/api/Disease",this.diseaseObj).subscribe(res=>{

            // 
            console.log(res);
      },
      err=>{
        console.log(err);     //
      })

    }
  }
  