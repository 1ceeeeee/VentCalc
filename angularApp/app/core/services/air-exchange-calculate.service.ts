import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Configuration } from '../../app.constants';
import { AirExchangeProject } from '../../models/airExchangeProject';

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
    return this.http.get<AirExchangeProject>(this.actionUrl + id + '/airexchange', { headers: this.headers });
  }

}
