//import { CityService } from './city.service';
//import { City } from './../../models/city';
import { AirExchangeProject } from './../../models/airExchangeProject';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
//import { Observable } from 'rxjs/Observable';
@Injectable()
export class DataService {

  private airExchangeProject = new BehaviorSubject<AirExchangeProject>(new AirExchangeProject());
  //private cities = new BehaviorSubject<City[]>([]);
  

  currentAirExchangeProject = this.airExchangeProject.asObservable();
  //currentCities = this.cities.asObservable();
  //cities: Observable<City[]> = null;

  // constructor(private cityService: CityService) { }

  changeAirExchangeProject(currentAirExchangeProject: AirExchangeProject) {
    this.airExchangeProject.next(currentAirExchangeProject)
    console.log(currentAirExchangeProject);
  }
  
}
