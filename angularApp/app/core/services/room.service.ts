import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Configuration } from '../../app.constants';
import { Room } from '../../models/room';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class RoomService {

  private headers: HttpHeaders;
  private actionUrl: string;

  constructor(private http: HttpClient, configuration: Configuration) {
    this.actionUrl = configuration.Server + 'api/rooms/';

    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');
  }

  getAll(): Observable<Room[]> {
    console.log(this.actionUrl);
    return this.http.get<Room[]>(this.actionUrl, { headers: this.headers });
  }

  add(roomToAdd: Room): Observable<Room> {
    console.log(this.actionUrl);
    return this.http.post<Room>(this.actionUrl, roomToAdd, { headers: this.headers });
  }

  delete(id: number): Observable<any> {
    return this.http.delete<any>(this.actionUrl + id, { headers: this.headers });
  }

  update(id: number, roomToUpdate: Room): Observable<Room> {
    return this.http.put<Room>(this.actionUrl + id, roomToUpdate, { headers: this.headers });
  }

  getById(id: number): Observable<Room> {
    return this.http.get<Room>(this.actionUrl + id, { headers: this.headers });
  }

}
