import { Credentials } from './../../models/credentials';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '../../../../node_modules/@angular/common/http';
import { Configuration } from '../../app.constants';
import { User } from '../../models/user';
import { Observable } from '../../../../node_modules/rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class UserService {

  private headers: HttpHeaders;
  private actionUrlAuth: string;
  private actionUrlReg: string;
  private loggedIn: boolean = false;
  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  authNavStatus$ = this._authNavStatusSource.asObservable();

  constructor(private http: HttpClient, configuration: Configuration) {

    this.actionUrlAuth = configuration.Server + 'api/auth/';
    this.actionUrlReg = configuration.Server + 'api/accounts/';    

    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');

    this.loggedIn = !!localStorage.getItem('currentUser_auth_token');
    this._authNavStatusSource.next(this.loggedIn);
  }

  register(user: User): Observable<User> {
    return this.http.post<User>(this.actionUrlReg, user, { headers: this.headers });
  }

  login(credentials: Credentials) {
    return this.http.post<Credentials>(this.actionUrlAuth,credentials, {headers: this.headers});
  }

  logout() {
    localStorage.removeItem('currentUser_auth_token');
    localStorage.removeItem('currentUser_id');
    this.loggedIn = false;
    this._authNavStatusSource.next(false);
  }

  storeCurrentUser(credentials: Credentials){
    localStorage.setItem('currentUser_auth_token', credentials.auth_token);
    localStorage.setItem('currentUser_id', credentials.id);
  }

  getCurrentUser(): Credentials{        
    return new Credentials(
      "",
      "",
      localStorage.getItem('currentUser_auth_token')!,
      0,
      localStorage.getItem('currentUser_id')!
    );
  }

  isLoggedIn(){
    return this.loggedIn;
  }

}
