
import { HomeComponent } from '../MasterPage/HomeComponent';
import { SecurityLogic } from '../Utilities/Utility.AuthGuard';

export const routes=[
    //{path:'',component:HomeComponent, canActivate : [SecurityLogic]},
    {path:'',component:HomeComponent,},
    {path:'Home',component:HomeComponent,canActivate : [SecurityLogic]},
    {path:'Patient',loadChildren:"../PatientInfo/PatientModule#PatientModule", canActivate : [SecurityLogic]},
    {path:'SearchPatient',loadChildren:"../Search/SearchModule#SearchModule", canActivate : [SecurityLogic]},
    {path:'PatientLogin',loadChildren:"../PatientLogin/PatientLoginModule#LoginhModule"}
];