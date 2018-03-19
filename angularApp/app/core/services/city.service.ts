import { HttpClient } from '@angular/common/http';
import { DataService } from './data.service';
import { Injectable } from '@angular/core';

@Injectable()
export class CityService extends DataService {
  constructor(http: HttpClient) {    
    super(http, "testGeography"); 
   }

}
