import { Project } from './../../models/project';
import { RoomType } from './../../models/roomType';
import { RoomService } from './../../core/services/room.service';
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
import { RoomTypeService } from '../../core/services/room-type.service';
import { ProjectService } from '../../core/services/project.service';


@Component({
  selector: 'app-calculator-form',
  templateUrl: './calculator-form.component.html'
})
export class CalculatorFormComponent implements OnInit {
  cities: City[] = [];
  buildingTypes: BuildingType[] = [];
  calculatorForm: CalculatorForm = new CalculatorForm();
  buildingKinds: BuildingKind[] = [];
  rooms: Room[] = [];
  roomTypes: RoomType[] = [];
  buildTypeChecked: number = -1;
  project: Project = new Project();  
  initedIdRoom: number = 0;


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
    public buildingTypeService: BuildingTypeService,
    public roomService: RoomService,
    public roomTypeService: RoomTypeService,
    public projectService: ProjectService) { }

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

  // Возвращает номер выбранной комнаты
  get roomNumber() {
    return this.form.get('room.roomNumber')!;
  }

  // Возвращает наименование комнаты
  get roomName() {
    return this.form.get('room.roomName')!;
  }

  // Возвращает длину комнаты
  get roomLength() {
    return this.form.get('room.roomLength')!;
  }

  // Возвращает ширину комнаты
  get roomWidth() {
    return this.form.get('room.roomWidth')!;
  }

  // Возвращает площадь команты
  get roomArea() {
    return this.form.get('room.roomArea')!;
  }

  // Возвращает высоту выбранной комнаты
  get roomHeight() {
    return this.form.get('room.roomHeight')!;
  }

  // Возвращает этаж выбранной комнаты
  get roomFloor() {
    return this.form.get('room.roomFloor')!;
  }

  // Возвращает количество людей в комнате
  get roomPeopleAmount() {
    return this.form.get('room.roomPeopleAmount')!;
  }

  // Возвращает выбранный ид географии объекта
  onCityChange() {
    this.calculatorForm.cityId = this.city.value;
  }


  onBuildTypeChange(id: number, i: number) {
    this.buildTypeChecked = i;
    this.calculatorForm.buildingTypeId = id;
  }

  isCheckedBuildType(i: number) {
    if (this.buildTypeChecked == i) {
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
  onSaveRoomClick() {    
    var roomTypeName = this.roomTypes
      .filter(rt => rt.id == this.form.get('room.roomName')!
        .value)[0]
      .roomTypeName;
    var rm = new Room(
      this.initedIdRoom,
      this.calculatorForm.cityId,
      this.calculatorForm.buildingTypeId,
      this.form.get('room.roomName')!.value,
      this.form.get('room.roomNumber')!.value,
      roomTypeName,
      this.form.get('room.roomLength')!.value,
      this.form.get('room.roomWidth')!.value,
      this.form.get('room.roomArea')!.value,
      this.form.get('room.roomHeight')!.value,
      this.form.get('room.roomFloor')!.value,
      this.form.get('room.roomPeopleAmount')!.value,
      0,
      0);

    console.log(rm);

    this.roomService.add(new Room(
      this.initedIdRoom,
      this.calculatorForm.cityId,
      this.calculatorForm.buildingTypeId,
      this.form.get('room.roomName')!.value,
      this.form.get('room.roomNumber')!.value,
      roomTypeName,
      this.form.get('room.roomLength')!.value,
      this.form.get('room.roomWidth')!.value,
      this.form.get('room.roomArea')!.value,
      this.form.get('room.roomHeight')!.value,
      this.form.get('room.roomFloor')!.value,
      this.form.get('room.roomPeopleAmount')!.value,
      0,
      this.project.id))
      .subscribe(
        () => {
          this.getAllRooms()
        },
        () => { },
        () => {
          console.log(this.rooms)
        }
      );

  }

  // Делает рассчет проекта
  onCalculateProject() {
    this.project.rooms = this.rooms;
    this.projectService.Add(this.project)
      .subscribe(
        data => this.project = data,
        () => { },
        () => { console.log(this.project) }
      );
  }

  // Возвращает все помещения из БД
  private getAllRooms() {
    this.roomService.getAll()
      .subscribe(
        data => this.rooms = data,
        () => { },
        () => {
          console.log(this.rooms);
          this.calculatorForm.cityId = this.rooms[0].cityId;
          this.calculatorForm.buildingTypeId = this.rooms[0].buildingTypeId;
        }
      )
  }

  initRoom(id: number, isCopy?: boolean) {
    var initedRoom = new Room();
    initedRoom = this.rooms.filter(r => r.id == id)[0];   
    this.initedIdRoom = id; 
    if (isCopy) {
      this.initedIdRoom = 0;
    }
    console.log(initedRoom.id, " " + this.initedIdRoom);
    console.log(id);
    this.form.get('room.roomName')!
      .setValue(initedRoom.roomTypeId);
    this.form.get('room.roomNumber')!
      .setValue(initedRoom.roomNumber);
    this.form.get('room.roomLength')!
      .setValue(initedRoom.length);
    this.form.get('room.roomWidth')!
      .setValue(initedRoom.width);
    this.form.get('room.roomArea')!
      .setValue(initedRoom.area);
    this.form.get('room.roomHeight')!
      .setValue(initedRoom.height);
    this.form.get('room.roomFloor')!
      .setValue(initedRoom.floor);
    this.form.get('room.roomPeopleAmount')!
      .setValue(initedRoom.peopleAmount);
  }

  onDeleteRoomClick(id: number) {
    this.roomService.delete(id)
      .subscribe(
        () => {
          this.getAllRooms();
        },
        () => { },
        () => { console.log("deleted room " + id) }
      );
  }

  // Создает проект
  private createProject() {
    this.project.id = 0;
    this.project.projectName = "";

    this.projectService.Add(this.project)
      .subscribe(
        data => this.project = data,
        () => { },
        () => { console.log(this.project) }
      )
  }

  ngOnInit() {

    this.getAllRooms();

    // Создает проект
    this.createProject();

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

    // Возвращает все типы помещений
    this.roomTypeService.getAll()
      .subscribe(
        data => this.roomTypes = data,
        () => { },
        () => { console.log(this.roomTypes) }
      )

  }

}