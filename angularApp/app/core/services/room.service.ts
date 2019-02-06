import { BaseService } from './base.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Configuration } from '../../app.constants';
import { Room } from '../../models/room';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class RoomService extends BaseService {
  
  private actionUrl: string;
  private serverUrl: string;

  constructor(private http: HttpClient, configuration: Configuration) {
    super();
    this.actionUrl = configuration.Server + 'api/rooms/';
    this.serverUrl = configuration.Server;    
  }

  getAll(): Observable<Room[]> {    
    return this.http.get<Room[]>(this.actionUrl, { headers: this.authHeaders });
  }

  getAllByIdProject(id: number): Observable<Room[]> {    
    return this.http.get<Room[]>(this.serverUrl + 'api/Projects/' + id + '/Rooms', { headers: this.authHeaders });
  }

  add(roomToAdd: Room): Observable<Room> {    
    return this.http.post<Room>(this.actionUrl, roomToAdd, { headers: this.authHeaders });
  }

  delete(id: number): Observable<any> {    
    return this.http.delete<any>(this.actionUrl + id, { headers: this.authHeaders });
  }

  update(id: number, roomToUpdate: Room): Observable<Room> {    
    return this.http.put<Room>(this.actionUrl + id, roomToUpdate, { headers: this.authHeaders });
  }

  getById(id: number): Observable<Room> {    
    return this.http.get<Room>(this.actionUrl + id, { headers: this.authHeaders });
  }

}
