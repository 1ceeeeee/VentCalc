import { BaseService } from './base.service';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Configuration } from '../../app.constants';
import { AirExchangeProject } from '../../models/airExchangeProject';

@Injectable()
export class AirExchangeCalculateService extends BaseService {
 
  private actionUrl: string;

  constructor(private http: HttpClient, configuration: Configuration) {
    super();
    this.actionUrl = configuration.Server + 'api/projects/';    
  }

  Get(id: number): Observable<AirExchangeProject> {    
    return this.http.get<AirExchangeProject>(this.actionUrl + id + '/airexchange', { headers: this.authHeaders });
  }
}
