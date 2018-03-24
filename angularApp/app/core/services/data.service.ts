// import 'rxjs/add/operator/map';
// import { HttpClient, HttpHeaders } from '@angular/common/http';
// import { Observable } from 'rxjs/Observable';
// import { Injectable } from '@angular/core';

// import 'rxjs/add/observable/of';
// import { BuildingType } from '../../models/buildingType';
//import { City } from '../../models/сity';


// @Injectable()
export class DataService {

  // private headers: HttpHeaders;

  // constructor(private http: HttpClient, private url: string) {
  //   console.log(url);
  //   this.headers = new HttpHeaders();
  //   this.headers = this.headers.set('Content-Type', 'application/json');
  //   this.headers = this.headers.set('Accept', 'application/json');
  // }

  // getAll() {
  //    let cities: City[] = [];     

  //   if(this.url.includes('testGeography')){      
  //     cities = [
  //       {
  //         id: 1,
  //         cityName: "Москва",
  //         tempOutSummer: 25,
  //         tempOutWinter: -25
  //       },
  //       {
  //         id: 2,
  //         cityName: "Петербург",
  //         tempOutSummer: 25,
  //         tempOutWinter: -25
  //       },
  //       {
  //         id: 3,
  //         cityName: "Ярославль",
  //         tempOutSummer: 25,
  //         tempOutWinter: -25
  //       },
  //       {
  //         id: 4,
  //         cityName: "Клин",
  //         tempOutSummer: 25,
  //         tempOutWinter: -25
  //       }
  //     ];
  //     return Observable.of(cities);
  //   }    
  //   else {
  //     return this.http.get<City[]>(this.url, { headers: this.headers });
  //   }   

  // }

  // getById(id: number){
  //   let buildTypes: BuildingType[] = [];
  //   if(id == 2){
  //     buildTypes = [
  //       {
  //         id: 1,
  //         name: "Производственные здания"
  //       },
  //       {
  //         id: 2,
  //         name: "Сборочные цеха заводов"
  //       },
  //       {
  //         id: 3,
  //         name: "Фабрики"
  //       },
  //       {
  //         id: 4,
  //         name: "Здания ТЭЦ"
  //       },
  //       {
  //         id: 5,
  //         name: "Котельные"
  //       },
  //       {
  //         id: 6,
  //         name: "Компрессорные"
  //       },
  //       {
  //         id: 7,
  //         name: "Склады"
  //       },
  //       {
  //         id: 8,
  //         name: "Гаражи"
  //       },
  //       {
  //         id: 9,
  //         name: "Депо"
  //       },
  //       {
  //         id: 10,
  //         name: "Административные, бытовые и т.п."
  //       }
  //     ];      
  //   }    
  //   return Observable.of(buildTypes);
  // }

}
