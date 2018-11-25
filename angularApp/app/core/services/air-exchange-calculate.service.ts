import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Configuration } from '../../app.constants';
import { AirExchangeProject } from '../../models/airExchangeProject';
import { TOKEN_NAME } from './user.service';

@Injectable()
export class AirExchangeCalculateService {

  private headers: HttpHeaders;
  private actionUrl: string;

  constructor(private http: HttpClient, configuration: Configuration) {
    this.actionUrl = configuration.Server + 'api/projects/';

    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');
  }

  Get(id: number): Observable<AirExchangeProject> {
    console.log(this.actionUrl + id + '/airexchange');
    let headers = this.headers;
    headers = headers.append('Authorization', `Bearer ${this.getToken()}`);
    return this.http.get<AirExchangeProject>(this.actionUrl + id + '/airexchange', { headers: this.headers });
  }

  getToken(): string | null {
    return localStorage.getItem(TOKEN_NAME);
  }

}
