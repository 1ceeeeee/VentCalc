import { BaseService } from './base.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Configuration } from '../../app.constants';
import { Observable } from 'rxjs/Observable';
import { RoomType } from '../../models/roomType';

@Injectable()
export class RoomTypeService extends BaseService {
  
  private actionUrl: string;

  constructor(private http: HttpClient, configuration: Configuration) {
    super();
    this.actionUrl = configuration.Server + 'api/roomtypes/';    
  }

  getAll(): Observable<RoomType[]> {        
    return this.http.get<RoomType[]>(this.actionUrl, { headers: this.authHeaders });
  } 

}
