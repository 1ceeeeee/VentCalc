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

  // getCities() {
  //   console.log('citites in data service: ' + this.cities);
  //   if (!this.cities) {
  //     this.cities = this.cityService
  //       .getAll();
  //   }
  //   return this.cities;
  // }

  // getFriends() {
  //   if (!this._friends) {
  //     this._friends = this._http
  //       .get('/api/friends.json')
  //       .pipe(
  //         map((res: Response) => res.json().friends),
  //         tap(friends => console.log('fetched friends')),
  //         publishReplay(1),
  //         refCount(),
  //       );
  //   }
  //   return this._friends;
  // }
  //changeCities(currentCities: City[]){
  //this.cities.next(currentCities);
  //console.log(currentCities);
  //}

  // getCities() {
  //   if (!this.cities) {
  //     this.cityService.getAll()
  //     .subscribe(
  //       data => {
  //         //console.log(this.cities.length),
  //           this.cities = data,
  //           this.dataService.changeCities(this.cities)
  //       },
  //       () => { },
  //       () => { console.log('cities.getAll()') }
  //     );
      
      
  //     this._http
  //       .get('/api/friends.json')
  //       .pipe(
  //         map((res: Response) => res.json().cities),
  //         tap(friends => console.log('fetched friends')),
  //         publishReplay(1),
  //         refCount(),
  //     );
  //   }
  //   return this._friends;
  // }

  // this.cityService.getAll()
  // .subscribe(
  //   data => {
  //     console.log(this.cities.length),
  //       this.cities = data,
  //       this.dataService.changeCities(this.cities)
  //   },
  //   () => { },
  //   () => { console.log('cities.getAll()') }
  // );

}
