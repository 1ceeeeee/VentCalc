export class RoomType {
    constructor(
        public id: number = 0,
        public roomTypeName: string = "",
        public roomTypeBuildingTypeName: string = "",
        public tempIn: number = 0,
        public humidityFrom: number = 0,
        public humidityTo: number = 0,
        public humidityRelative: number = 0,
        public inflow: number = 0,
        public exhaust: number = 0,
        public unit: string = "",
        public isForPeople: boolean = false
    ) { }

}