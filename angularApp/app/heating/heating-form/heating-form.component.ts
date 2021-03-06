import { Heating } from './../../models/heating';
import { HeatingService } from './../../core/services/heating.service';
import { Component, OnInit, Input } from '@angular/core';
import { AirExchangeProject } from '../../models/airExchangeProject';

@Component({
  selector: 'heating-form',
  templateUrl: './heating-form.component.html'
})
export class HeatingFormComponent implements OnInit {

  @Input()
  airExchangeProject: AirExchangeProject = new AirExchangeProject();

  projectId: number = 0;
  heating: Heating[] = [];

  constructor(private heatingService: HeatingService) { }

  edit(){    
    this.heatingService.edit(this.heating)
    .subscribe(
      data => {        
        console.log('data: ' + data);
      }
    )
    console.log(JSON.stringify(this.heating));
  }

  ngOnInit() {
  }

  ngOnChanges() {
    this.projectId = this.airExchangeProject.id;
    console.log(`projectId: ${this.projectId} airExchangeProject.id: ${this.airExchangeProject.id}`);
    this.heatingService.getByProjectId(this.airExchangeProject.id)
    .subscribe(
      data => { 
        this.heating = data;
        console.log(this.heating);
      },
      error => { console.log(error)}

    )
  }

}
