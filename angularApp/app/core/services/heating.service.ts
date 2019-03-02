import { Heating } from './../../models/heating';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Configuration } from '../../app.constants';
import { Observable } from 'rxjs/Observable';
import { BaseService } from './base.service';

@Injectable()
export class HeatingService extends BaseService {

  private actionUrl: string;

  constructor(private http: HttpClient, configuration: Configuration) {
    super();
    this.actionUrl = configuration.Server + 'api/heatingVentilationSystems/';
  }

  getById(id: number): Observable<Heating> {
    return this.http.get<Heating>(this.actionUrl + id, { headers: this.authHeaders });
  }

  getByProjectId(id: number): Observable<Heating[]> {
    return this.http.get<Heating[]>(this.actionUrl + 'getByProjectId/' + id, { headers: this.authHeaders });
  }

  edit(hts: Heating[]): Observable<Heating[]> {
    return this.http.post<Heating[]>(this.actionUrl, hts, { headers: this.authHeaders });
  }

}
