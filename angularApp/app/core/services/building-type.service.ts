import { BuildingType } from './../../models/buildingType';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Configuration } from '../../app.constants';


@Injectable()
export class BuildingTypeService {

  private headers: HttpHeaders;
  private actionUrl: string;

  constructor(private http: HttpClient, configuration: Configuration) { 
    this.actionUrl = configuration.Server + 'api/buildingtypes/';

    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json'); 
    
  }

  getAll(): Observable<BuildingType[]>{
    console.log(this.actionUrl); 
    return this.http.get<BuildingType[]>(this.actionUrl, {headers: this.headers});
  }

  getByIdKind(id: number): Observable<BuildingType[]>{
    return this.http.get<BuildingType[]>(this.actionUrl + id, { headers: this.headers });  
  }

}
