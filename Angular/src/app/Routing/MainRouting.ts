
import { HomeComponent } from '../MasterPage/HomeComponent';
//import { PatientLoginComponent } from '../PatientLogin/PatientLogin.component';
export const routes=[
    {path:'',component:HomeComponent},
    {path:'Home',component:HomeComponent},
    {path:'Patient',loadChildren:"../PatientInfo/PatientModule#PatientModule"},
    {path:'SearchPatient',loadChildren:"../Search/SearchModule#SearchModule"},
    {path:'PatientLogin',loadChildren:"../PatientLogin/PatientLoginModule#LoginhModule"}
];