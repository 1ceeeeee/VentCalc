import { AirExchangeProject } from './../../models/airExchangeProject';
import { DataService } from './../../core/services/data.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-airexchange-form',
  templateUrl: './airexchange-form.component.html'
})
export class AirexchangeFormComponent implements OnInit {

  airExchangeProject: AirExchangeProject = new AirExchangeProject();

  constructor(
    private dataService: DataService
  ) { }

  ngOnInit() {
    this.dataService.currentAirExchangeProject
      .subscribe(
        data => {
          this.airExchangeProject = data
        },
        () => { },
        () => { }
      )
  }

}
