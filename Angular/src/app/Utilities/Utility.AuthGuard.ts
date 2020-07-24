import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot,RouterStateSnapshot } from '@angular/router';
import { User } from '../PatientLogin/PatientLogin.Model';
import { Observable } from 'rxjs';
 
 
@Injectable()
export class SecurityLogic implements CanActivate {
 
    constructor(private _router:Router, public _user:User ) {
    }
     
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
     if(this._user.token.length != 0){
        return true; 
     }
    
     this._router.navigate(['/PatientLogin/Login']);
     return false;
    }
}
