import { AirExchangeProject } from './../../models/airExchangeProject';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
@Injectable()
export class DataService {

  private airExchangeProject = new BehaviorSubject<AirExchangeProject>(new AirExchangeProject());
  currentAirExchangeProject = this.airExchangeProject.asObservable();

  constructor() { }

  changeAirExchangeProject(currentAirExchangeProject: AirExchangeProject) {
    this.airExchangeProject.next(currentAirExchangeProject)
  }

}
