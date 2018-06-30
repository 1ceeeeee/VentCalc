import { BuildingKind } from './../../models/buildingKind';
import { Observable } from 'rxjs/Observable';
import { Configuration } from './../../app.constants';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class BuildingKindService {

  private headers: HttpHeaders;
  private actionUrl: string;

  constructor(private http: HttpClient, configuration: Configuration) {

    this.actionUrl = configuration.Server + 'api/buildingkinds/';

    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');
   }

   getAll(): Observable<BuildingKind[]>{    
     return this.http.get<BuildingKind[]>(this.actionUrl, {headers: this.headers});
   }

}
