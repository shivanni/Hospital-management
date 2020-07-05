import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent,HttpInterceptor} from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../PatientLogin/PatientLogin.Model';
import { Token } from '@angular/compiler';

@Injectable()
export class MyJwtInterceptor implements HttpInterceptor {
    constructor(private _user:User){}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${this._user.token}`
        
        }
      });
    

    return next.handle(request);
  }
}
