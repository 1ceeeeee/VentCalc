import { Heating } from './../../models/heating';
import { Injectable } from '@angular/core';
import { TOKEN_NAME } from './user.service';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Configuration } from '../../app.constants';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class HeatingService {

  private headers: HttpHeaders;
  private actionUrl: string;
  
  constructor(private http: HttpClient, configuration: Configuration) { 
    this.actionUrl = configuration.Server + 'api/heatingVentilationSystems/';
  }

  getById(id: number): Observable<Heating>{
    let headers = this.headers;        
    headers = headers.append('Authorization', `Bearer ${this.getToken()}`);
    return this.http.get<Heating>(this.actionUrl + id, {headers: headers});
  }

  getByProjectId(id: number): Observable<Heating>{
    let headers = this.headers;        
    headers = headers.append('Authorization', `Bearer ${this.getToken()}`);
    return this.http.get<Heating>(this.actionUrl + 'getByProjectId/' + id, {headers: headers});
  }

  getToken(): string | null {
    return localStorage.getItem(TOKEN_NAME);
  }

}
