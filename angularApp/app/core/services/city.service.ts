import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Configuration } from '../../app.constants';
import { City } from '../../models/city';



@Injectable()
export class CityService extends BaseService {
  
  private actionUrl: string;

  constructor(private http: HttpClient, configuration: Configuration) {    
    super();
    this.actionUrl = configuration.Server + 'api/cities/'; 
  }

  getAll(): Observable<City[]>{      
    return this.http.get<City[]>(this.actionUrl, { headers: this.authHeaders });  
  }

  

}
