import { BaseService } from './base.service';
import { BuildingKind } from './../../models/buildingKind';
import { Observable } from 'rxjs/Observable';
import { Configuration } from './../../app.constants';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class BuildingKindService extends BaseService {

  private actionUrl: string;

  constructor(private http: HttpClient, configuration: Configuration) {
    super();
    this.actionUrl = configuration.Server + 'api/buildingkinds/';    
   }

   getAll(): Observable<BuildingKind[]>{    
     return this.http.get<BuildingKind[]>(this.actionUrl, {headers: this.authHeaders});
   }

}
