import { BaseService } from './base.service';
import { BuildingType } from './../../models/buildingType';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Configuration } from '../../app.constants';


@Injectable()
export class BuildingTypeService extends BaseService {

  private actionUrl: string;
  private actionUrlById: string;

  constructor(private http: HttpClient, configuration: Configuration) { 
    super();
    this.actionUrl = configuration.Server + 'api/buildingtypes/';
    this.actionUrlById = configuration.Server + 'api/buildingkinds/';  
  }

  getAll(): Observable<BuildingType[]>{    
    return this.http.get<BuildingType[]>(this.actionUrl, {headers: this.authHeaders});
  }

  getByIdKind(id: number): Observable<BuildingType[]>{     
    return this.http.get<BuildingType[]>(this.actionUrlById + id + '/buildingtypes', { headers: this.authHeaders });  
  }

}
