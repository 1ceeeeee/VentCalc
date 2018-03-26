import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BuildingKindService } from './../../core/services/building-kind.service';
import { BuildingKind } from './../../models/buildingKind';
import { CalculatorForm } from './../../models/calculatorForm';
import { BuildingType } from './../../models/buildingType';
import { City } from '../../models/city';
import { Room } from '../../models/room';
import { BuildingTypeService } from '../../core/services/building-type.service';
import { CityService } from '../../core/services/city.service';


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
    city: new FormControl('', Validators.required),
    buildingType: new FormControl('', Validators.required),
    buildingKind: new FormControl('', Validators.required),
    room: new FormGroup({
      roomNumber: new FormControl('', Validators.required),
      roomName: new FormControl('', Validators.required),
      roomLength: new FormControl('', Validators.required),
      roomWidth: new FormControl('', Validators.required),
      roomArea: new FormControl('', Validators.required),
      roomHeight: new FormControl('', Validators.required),
      roomFloor: new FormControl('', Validators.required),
      roomPeopleAmount: new FormControl('', Validators.required)
    })
  });

  constructor(
    public cityService: CityService,
    public buildinKindService: BuildingKindService,
    public buildingTypeService: BuildingTypeService) { }

  // Возвращает значение контрола географии
  get city() {
    return this.form.get('city')!;
  }

  // Возвращает значение контрола видов зданий
  get buildType() {
    return this.form.get('buildingType')!;
  }

  // Возвращает ид выбранного вида зданий
  get selectedBuildingKind() {
    return this.calculatorForm.buildKindId!;
  }

  // Возвращает выбранный ид географии объекта
  onCityChange() {
    this.calculatorForm.cityId = this.city.value;
  }

  
  onBuildTypeChange(id: number, i: number) {
    console.log('onBuildingTypeChanged: ${id} selected index: ${i}');
    this.buildTypeChecked = i;
    this.calculatorForm.buildingTypeId = id;
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
    this.calculatorForm.buildKindId = id;
    this.buildingTypeService.getByIdKind(id)
      .subscribe(
        data => this.buildingTypes = data,
        () => { },
        () => { console.log(this.buildingTypes) }
      );
  }

  // Добавляет помещение к общему списку помещений
  onSaveRoomClick(){
    
    // this.calculatorForm.rooms.push(new Room(0,this.calculatorForm.cityId,this.calculatorForm.buildingTypeId,))
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