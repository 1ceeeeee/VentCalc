import { DataService } from './../../core/services/data.service';
import { AirExchangeProject } from './../../models/airExchangeProject';
import { AirExchangeCalculateService } from './../../core/services/air-exchange-calculate.service';
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
import { Router } from '@angular/router';


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
  projectId: number = 0;
  initedIdRoom: number = 0;
  airExchangeProject: AirExchangeProject = new AirExchangeProject();

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
    public projectService: ProjectService,
    public airExchangeService: AirExchangeCalculateService,
    private dataService: DataService,
    public router: Router
  ) { }

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
  onCityChange(value: any) {
    this.calculatorForm.cityId = value;//this.city.value;
    console.log(this.calculatorForm.cityId);
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
        () => { }
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
      this.project.id);

    if (this.initedIdRoom == 0) {
      this.roomService.add(rm)
        .subscribe(
          () => {
            console.log(rm);
            this.getAllRooms(this.project.id);
          },
          (error) => {
            console.log(error);
          }
        );
    } else {
      this.roomService.update(this.initedIdRoom, rm)
        .subscribe(
          () => {
            this.getAllRooms(this.project.id);
          },
          () => { },
          () => {
            console.log("Обновлено помещения с ид: " + this.initedIdRoom);

          }
        )
    }
  }

  // Делает рассчет проекта
  onCalculateProjectClick() {
    this.airExchangeService.Get(this.project.id)
      .subscribe(
        data => {
          this.airExchangeProject = data,
            this.dataService.changeAirExchangeProject(this.airExchangeProject)
        },
        () => { },
        () => {
          console.log(this.airExchangeProject);
        }
      );
  }

  // Возвращает все помещения из БД
  private getAllRooms(id: number) {
    this.roomService.getAllByIdProject(id)
      .subscribe(
        data => this.rooms = data,
        () => { },
        () => {
          console.log(this.rooms);
          if (this.rooms.length > 0) {
            this.calculatorForm.cityId = this.rooms[0].cityId;
            this.calculatorForm.buildingTypeId = this.rooms[0].buildingTypeId;
          }
        }
      )
  }

  initRoom(id: number, isCopy?: boolean) {
    var initedRoom = new Room();
    initedRoom = this.rooms.filter(r => r.id == id)[0];
    this.initedIdRoom = id;
    // if (initedRoom) {
    //   this.projectId = initedRoom.projectId;
    // }
    if (isCopy) {
      this.initedIdRoom = 0;
    }
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
          this.getAllRooms(this.project.id);
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
        () => { }
      )
  }

  private initCities() {

    //this.dataService.getCities()
    // .subscribe(
    //   data => {
    //     this.cities = data
    //   },
    //   () => {},
    //   () => {console.log(this.cities)}
    // )
    // this.dataService.currentCities
    //   .subscribe(
    //     data => {
    //       this.cities = data,
    //         console.log(this.cities),
    //         //console.log('from cash'),
    //         console.log(this.cities.length)
    //     },
    //     () => { },
    //     () => {console.log('from cash') }
    //   )
      if (this.cities.length == 0) {
        // Возвращает все географии городов из бд
        this.cityService.getAll()
          .subscribe(
            data => {
              console.log(this.cities.length),
                this.cities = data
                //this.dataService.changeCities(this.cities)
            },
            () => { },
            () => { console.log('cities.getAll()') }
          );
      }

  }

  /* Полезный код если надо будет объединять ячейки в икселе вручную */
  // exportFile() {
  //   /* create new workbook */
  //   var workbook = XLSX.utils.book_new();

  //   XLSX.writeFile({
  //     SheetNames:["Sheet1"],
  //     Sheets: {
  //       Sheet1: {
  //         "!ref": "A1:I2",
  //         A1:{t:'s', v:"№ пом"},
  //         B1:{t:'s', v:"Наименование помещения", wch:15},
  //         C1:{t:'s', v:"Tвн., С"},
  //         D1:{t:'s', v:"Площадь помещения, м2"},
  //         E1:{t:'s', v:"Объем помещения, м3"},
  //         F1:{t:'s', v:"Кратность воздухообмена"},
  //         F2:{t:'s', v:"Приток"},
  //         G2:{t:'s', v:"Вытяжка"},
  //         H1:{t:'s', v:"Расчетный расход воздуха м3/ч"},
  //         H2:{t:'s', v:"Приток"},
  //         I2:{t:'s', v:"Вытяжка"},
  //         "!merges":[
  //           {s:{r:0,c:0},e:{r:1,c:0}}, /* A1:A2 */
  //           {s:{r:0,c:1},e:{r:1,c:1}}, /* B1:B2 */
  //           {s:{r:0,c:2},e:{r:1,c:2}}, /* C1:C2 */
  //           {s:{r:0,c:3},e:{r:1,c:3}}, /* D1:D2 */
  //           {s:{r:0,c:4},e:{r:1,c:4}}, /* E1:E2 */
  //           {s:{r:0,c:5},e:{r:0,c:6}}, /* F1:G1 */
  //           {s:{r:0,c:7},e:{r:0,c:8}} /* H1:I1 */
  //         ]
  //       }
  //     }
  //   }, 'test.xlsx');
  //   XLSX.writeFile(workbook, 'out.xls');
  // }

  ngOnInit() {

    this.dataService.currentAirExchangeProject
      .subscribe(
        data => {
          this.airExchangeProject = data
        },
        () => { },
        () => { }
      );

    // Создает проект
    this.createProject();

    this.initCities();

    // Возвращает все виды зданий из бд
    this.buildinKindService.getAll()
      .subscribe(
        data => this.buildingKinds = data,
        () => { },
        () => { }
      );

    // Возвращает все типы помещений
    this.roomTypeService.getAll()
      .subscribe(
        data => this.roomTypes = data,
        () => { },
        () => { }
      )

  }

}