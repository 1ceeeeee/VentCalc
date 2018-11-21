import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Configuration } from '../../app.constants';
import { Observable } from 'rxjs/Observable';
import { RoomType } from '../../models/roomType';
import { TOKEN_NAME } from './user.service';

@Injectable()
export class RoomTypeService {

  private headers: HttpHeaders;
  private actionUrl: string;

  constructor(private http: HttpClient, configuration: Configuration) {
    this.actionUrl = configuration.Server + 'api/roomtypes/';

    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');
  }

  getAll(): Observable<RoomType[]> {    
    let headers = this.headers;
    headers = headers.append('Authorization', `Bearer ${this.getToken()}`);
    return this.http.get<RoomType[]>(this.actionUrl, { headers: this.headers });
  }
  
  getToken(): string | null {
    return localStorage.getItem(TOKEN_NAME);
  }

}
