
import { HomeComponent } from '../MasterPage/HomeComponent';
import { SecurityLogic } from '../Utilities/Utility.AuthGuard';

export const routes=[
  
    {path:'',component:HomeComponent,},
    {path:'Home',component:HomeComponent,canActivate : [SecurityLogic]},
    {path:'Patient',loadChildren:"../PatientAddDetails/PatientModule#PatientModule", canActivate : [SecurityLogic]},
    {path:'SearchPatient',loadChildren:"../Search/SearchModule#SearchModule", canActivate : [SecurityLogic]},
    {path:'PatientLogin',loadChildren:"../PatientLogin/PatientLoginModule#LoginhModule"},
    {path:'Disease',loadChildren:"../Disease/DiseaseModule#DiseaseModule", canActivate : [SecurityLogic]},

    //{path:'registeration',loadChildren:"../registration/RegistrationModule#RegistrationModule", canActivate : [SecurityLogic]},
];