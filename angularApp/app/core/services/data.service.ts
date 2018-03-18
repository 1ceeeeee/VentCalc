import { Geography } from './../../models/geography';
import 'rxjs/add/operator/map';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
// import { Injectable } from '@angular/core';

import 'rxjs/add/observable/of';
import { BuildingType } from '../../models/buildingType';


// @Injectable()
export class DataService {

  private headers: HttpHeaders;

  constructor(private http: HttpClient, private url: string) {
    console.log(url);
    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');
  }

  getAll() {
     let geog: Geography[] = [];     

    if(this.url.includes('testGeography')){      
      geog = [
        {
          id: 1,
          name: "Москва"
        },
        {
          id: 2,
          name: "Петербург"
        },
        {
          id: 3,
          name: "Ярославль"
        },
        {
          id: 4,
          name: "Клин"
        }
      ];
      return Observable.of(geog);
    }    
    else {
      return this.http.get<Geography[]>(this.url, { headers: this.headers });
    }   

  }

  getById(id: number){
    let buildTypes: BuildingType[] = [];
    if(id == 2){
      buildTypes = [
        {
          id: 1,
          name: "Производственные здания"
        },
        {
          id: 2,
          name: "Сборочные цеха заводов"
        },
        {
          id: 3,
          name: "Фабрики"
        },
        {
          id: 4,
          name: "Здания ТЭЦ"
        },
        {
          id: 5,
          name: "Котельные"
        },
        {
          id: 6,
          name: "Компрессорные"
        },
        {
          id: 7,
          name: "Склады"
        },
        {
          id: 8,
          name: "Гаражи"
        },
        {
          id: 9,
          name: "Депо"
        },
        {
          id: 10,
          name: "Административные, бытовые и т.п."
        }
      ];      
    }    
    return Observable.of(buildTypes);
  }

}
