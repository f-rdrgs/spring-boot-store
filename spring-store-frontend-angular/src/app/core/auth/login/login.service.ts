
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators';
import {  LoginAttempt ,LoginSuccess } from 'src/app/shared/models/auth/login-data';
import { AppConfigService } from '../../app-config.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  r : HttpClient;
  constructor(private http: HttpClient, private config: AppConfigService) { 
    this.r = http;
  }

  /**
   * login
   */
  public login(data:LoginAttempt) : Observable<LoginSuccess>{
    return this.r.post<LoginSuccess>(this.config.getAPIURL(), data).pipe((d) => {return d});
  }
  
}
