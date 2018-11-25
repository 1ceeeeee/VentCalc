import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Configuration } from '../../app.constants';
import { Room } from '../../models/room';
import { Observable } from 'rxjs/Observable';
import { TOKEN_NAME } from './user.service';

@Injectable()
export class RoomService {

  private headers: HttpHeaders;
  private actionUrl: string;
  private serverUrl: string;

  constructor(private http: HttpClient, configuration: Configuration) {
    this.actionUrl = configuration.Server + 'api/rooms/';
    this.serverUrl = configuration.Server;
    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');
  }

  getAll(): Observable<Room[]> {
    console.log(this.actionUrl);
    let headers = this.headers;
    headers = headers.append('Authorization', `Bearer ${this.getToken()}`);
    return this.http.get<Room[]>(this.actionUrl, { headers: headers });
  }

  getAllByIdProject(id: number): Observable<Room[]> {
    let headers = this.headers;
    headers = headers.append('Authorization', `Bearer ${this.getToken()}`);
    return this.http.get<Room[]>(this.serverUrl + 'api/Projects/' + id + '/Rooms', { headers: headers });
  }

  add(roomToAdd: Room): Observable<Room> {
    console.log(this.actionUrl);
    let headers = this.headers;
    headers = headers.append('Authorization', `Bearer ${this.getToken()}`);
    return this.http.post<Room>(this.actionUrl, roomToAdd, { headers: headers });
  }

  delete(id: number): Observable<any> {
    let headers = this.headers;
    headers = headers.append('Authorization', `Bearer ${this.getToken()}`);
    return this.http.delete<any>(this.actionUrl + id, { headers: headers });
  }

  update(id: number, roomToUpdate: Room): Observable<Room> {
    console.log(roomToUpdate);
    let headers = this.headers;
    headers = headers.append('Authorization', `Bearer ${this.getToken()}`);
    return this.http.put<Room>(this.actionUrl + id, roomToUpdate, { headers: headers });
  }

  getById(id: number): Observable<Room> {
    let headers = this.headers;
    headers = headers.append('Authorization', `Bearer ${this.getToken()}`);
    return this.http.get<Room>(this.actionUrl + id, { headers: headers });
  }

  getToken(): string | null {
    return localStorage.getItem(TOKEN_NAME);
  }

}
