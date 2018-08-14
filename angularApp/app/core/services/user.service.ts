import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '../../../../node_modules/@angular/common/http';
import { Configuration } from '../../app.constants';
import { User } from '../../models/user';
import { Observable } from '../../../../node_modules/rxjs/Observable';

@Injectable()
export class UserService {

  private headers: HttpHeaders;
  private actionUrl: string;
  
  constructor(private http: HttpClient, configuration: Configuration) {

    this.actionUrl = configuration.Server + 'api/accounts/';
    console.log(this.actionUrl);

    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');  
   }

   Create(user: User): Observable<User> {    
    return this.http.post<User>(this.actionUrl, user, { headers: this.headers });
  }

}
