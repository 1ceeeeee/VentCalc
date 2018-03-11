import { BuildingKindService } from './../../core/services/building-kind.service';
import { BuildingKind } from './../../models/buildingKind';
import { CalculatorForm } from './../../models/calculatorForm';
import { BuildingType } from './../../models/buildingType';
import { Geography } from './../../models/geography';
import { GeographyService } from './../../core/services/geography.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-calculator-form',
  templateUrl: './calculator-form.component.html'
})
export class CalculatorFormComponent implements OnInit {
  geographies: Geography[] = [];
  buildingTypes: BuildingType[] = [];
  calculatorForm: CalculatorForm = new CalculatorForm();
  buildingKinds: BuildingKind[] = [];
  buildKindChecked: number = -1;


  form = new FormGroup({
    geography: new FormControl('', Validators.required),
    buildingType: new FormControl('', Validators.required),
    buildingKind: new FormControl('',Validators.required)
  });

  constructor(
    private serviceGeography: GeographyService,
    private serviceBuildingKind: BuildingKindService) { }

  // Возвращает значение контрола географии
  get geography() {
    return this.form.get('geography')!;
  }

  get buildKind(){
    return this.form.get('buildingKind')!;
  }
  
  // Возвращает ид выбранного типа зданий
  get selectedBuildingType() {
    return this.calculatorForm.idBuildingType!;
  }

  // Возвращает выбранный ид географии объекта
  onGeographyChange() {
    this.calculatorForm.idGeography = this.geography.value;
  }

  onBuildKindChange(id: number, i: number){
    console.log('onBuildingTypeChanged: ${id} selected index: ${i}');
    this.buildKindChecked = i;
    this.calculatorForm.idBuildKind = id;
  }

  isCheckedBuildKind(i: number){
    if(this.buildKindChecked == i){
      console.log('isCheckedBuildKind: ${this.buildKindChecked}  selected index: ${i}');
      return true;
    }
    return false;
  }

  // Возвращает выбранный из UI ид типа здания
  buildingTypeSelect(id: number) {
    this.calculatorForm.idBuildingType = id;
    this.serviceBuildingKind.getById(id)
      .subscribe(
        data => this.buildingKinds = data,
        () => { },
        () => { console.log(this.buildingKinds) }
      );
  }

  ngOnInit() {
    // Возвращает все географии городов из бд
    this.serviceGeography.getAll()
      .subscribe(
        data => this.geographies = data,
        () => { },
        () => { console.log(this.geographies) }
      );
    // Возвращает все типы зданий из бд
    this.buildingTypes = [
      {
        id: 1,
        name: "Гражданские"
      },
      {
        id: 2,
        name: "Промышленные"
      },
      {
        id: 3,
        name: "Сельскохозяйственные"
      },
    ];
  }

}
