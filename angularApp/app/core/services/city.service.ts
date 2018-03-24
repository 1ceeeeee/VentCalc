import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Configuration } from '../../app.constants';
import { City } from '../../models/city';



@Injectable()
export class CityService {

  private headers: HttpHeaders;
  private actionUrl: string;

  constructor(private http: HttpClient, configuration: Configuration) {    

    this.actionUrl = configuration.Server + 'api/cities/';

    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');    
  }

  getAll(): Observable<City[]>{
    console.log(this.actionUrl);    
    return this.http.get<City[]>(this.actionUrl, { headers: this.headers });  
  }

  

}
