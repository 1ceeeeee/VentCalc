import { BuildingKind } from './../../models/buildingKind';
import { CalculatorForm } from './../../models/calculatorForm';
import { BuildingType } from './../../models/buildingType';
import { Geography } from './../../models/geography';
import { GeographyService } from './../../core/services/geography.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BuildingTypeService } from '../../core/services/building-type.service';

@Component({
  selector: 'app-calculator-form',
  templateUrl: './calculator-form.component.html'
})
export class CalculatorFormComponent implements OnInit {
  geographies: Geography[] = [];
  buildingTypes: BuildingType[] = [];
  calculatorForm: CalculatorForm = new CalculatorForm();
  buildingKinds: BuildingKind[] = [];
  buildTypeChecked: number = -1;


  form = new FormGroup({
    geography: new FormControl('', Validators.required),
    buildingType: new FormControl('', Validators.required),
    buildingKind: new FormControl('',Validators.required)
  });

  constructor(
    private serviceGeography: GeographyService,
    private serviceBuildingType: BuildingTypeService) { }

  // Возвращает значение контрола географии
  get geography() {
    return this.form.get('geography')!;
  }

  get buildType(){
    return this.form.get('buildingType')!;
  }
  
  // Возвращает ид выбранного вида зданий
  get selectedBuildingKind() {
    return this.calculatorForm.idBuildKind!;
  }

  // Возвращает выбранный ид географии объекта
  onGeographyChange() {
    this.calculatorForm.idGeography = this.geography.value;
  }

  onBuildTypeChange(id: number, i: number){
    console.log('onBuildingTypeChanged: ${id} selected index: ${i}');
    this.buildTypeChecked = i;
    this.calculatorForm.idBuildingType = id;
  }

  isCheckedBuildType(i: number){
    if(this.buildTypeChecked == i){
      console.log('isCheckedBuildType: ${this.buildTypeChecked}  selected index: ${i}');
      return true;
    }
    return false;
  }

  // Возвращает выбранный из UI ид типа здания
  buildingKindSelect(id: number) {
    this.calculatorForm.idBuildKind = id;
    this.serviceBuildingType.getById(id)
      .subscribe(
        data => this.buildingTypes = data,
        () => { },
        () => { console.log(this.buildingTypes) }
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
    // Возвращает все виды зданий из бд
    this.buildingKinds = [
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
