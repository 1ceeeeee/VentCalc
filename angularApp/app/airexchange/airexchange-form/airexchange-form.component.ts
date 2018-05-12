import { AirExchangeProject } from './../../models/airExchangeProject';
import { DataService } from './../../core/services/data.service';
import * as XLSX from 'xlsx';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'airexchange-form',
  templateUrl: './airexchange-form.component.html'
})
export class AirexchangeFormComponent implements OnInit {

  airExchangeProject: AirExchangeProject = new AirExchangeProject();

  constructor(
    private dataService: DataService
  ) { }

  exportFile() {
    var tbl = XLSX.utils.table_to_book(document.getElementById('airExchange-table'), {raw:true}); 
    var fileName = 'Расчет воздухообменов_' + this.airExchangeProject.id + '.xls';
    XLSX.writeFile(tbl, fileName, {cellStyles:true});
  }

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
