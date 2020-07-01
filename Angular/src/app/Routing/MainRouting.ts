
import { HomeComponent } from '../MasterPage/HomeComponent';
export const routes=[
    {path:'',component:HomeComponent},
    {path:'Home',component:HomeComponent},
    {path:'Patient',loadChildren:"../PatientInfo/PatientModule#PatientModule"},
    {path:'SearchPatient',loadChildren:"../Search/SearchModule#SearchModule"}
];