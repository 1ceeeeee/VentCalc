import { Credentials } from './../../models/credentials';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '../../../../node_modules/@angular/common/http';
import { Configuration } from '../../app.constants';
import { User } from '../../models/user';
import { Observable } from '../../../../node_modules/rxjs/Observable';

@Injectable()
export class UserService {

  private headers: HttpHeaders;
  private actionUrlAuth: string;
  private actionUrlReg: string;

  constructor(private http: HttpClient, configuration: Configuration) {

    this.actionUrlAuth = configuration.Server + 'api/auth/';
    this.actionUrlReg = configuration.Server + 'api/accounts/';    

    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');
  }

  register(user: User): Observable<User> {
    return this.http.post<User>(this.actionUrlReg, user, { headers: this.headers });
  }

  login(credentials: Credentials) : Observable<Credentials> {
    return this.http.post<Credentials>(this.actionUrlAuth,credentials, {headers: this.headers});
  }
}
