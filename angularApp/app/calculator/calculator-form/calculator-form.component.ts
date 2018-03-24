import { BuildingKindService } from './../../core/services/building-kind.service';
import { BuildingKind } from './../../models/buildingKind';
import { CalculatorForm } from './../../models/calculatorForm';
import { BuildingType } from './../../models/buildingType';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BuildingTypeService } from '../../core/services/building-type.service';
import { CityService } from '../../core/services/city.service';
import { City } from '../../models/city';
import { Room } from '../../models/room';

@Component({
  selector: 'app-calculator-form',
  templateUrl: './calculator-form.component.html'
})
export class CalculatorFormComponent implements OnInit {
  cities: City[] = [];
  buildingTypes: BuildingType[] = [];
  calculatorForm: CalculatorForm = new CalculatorForm();
  buildingKinds: BuildingKind[] = [];
  room: Room = new Room();
  buildTypeChecked: number = -1;


  form = new FormGroup({
    cityControl: new FormControl('', Validators.required),
    buildingType: new FormControl('', Validators.required),
    buildingKind: new FormControl('', Validators.required),
    roomAdd: new FormControl('', Validators.required)
  });

  constructor(
    public cityService: CityService,
    public buildinKindService: BuildingKindService,
    public buildingTypeService: BuildingTypeService) { }

  // Возвращает значение контрола географии
  get cityControl() {
    return this.form.get('cityControl')!;
  }

  get buildType() {
    return this.form.get('buildingType')!;
  }

  // Возвращает ид выбранного вида зданий
  get selectedBuildingKind() {
    return this.calculatorForm.idBuildKind!;
  }

  // Возвращает выбранный ид географии объекта
  onCityChange() {
    this.calculatorForm.idCity = this.cityControl.value;
  }

  onBuildTypeChange(id: number, i: number) {
    console.log('onBuildingTypeChanged: ${id} selected index: ${i}');
    this.buildTypeChecked = i;
    this.calculatorForm.idBuildingType = id;
  }

  isCheckedBuildType(i: number) {
    if (this.buildTypeChecked == i) {
      console.log('isCheckedBuildType: ${this.buildTypeChecked}  selected index: ${i}');
      return true;
    }
    return false;
  }

  // Возвращает выбранный из UI ид типа здания
  buildingKindSelect(id: number) {
    this.calculatorForm.idBuildKind = id;
    this.buildingTypeService.getByIdKind(id)
      .subscribe(
        data => this.buildingTypes = data,
        () => { },
        () => { console.log(this.buildingTypes) }
      );
  }

  ngOnInit() {
    // Возвращает все географии городов из бд
    this.cityService.getAll()
      .subscribe(
        data => this.cities = data,
        () => { },
        () => { console.log(this.cities) }
      );

    // Возвращает все виды зданий из бд
    this.buildinKindService.getAll()
      .subscribe(
        data => this.buildingKinds = data,
        () => { },
        () => { console.log(this.buildingKinds) }
      );


  }

}