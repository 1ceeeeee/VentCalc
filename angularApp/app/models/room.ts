export class Room {
    constructor(    
        public id: number = 0,
        public cityId: number = 0,
        public buildingTypeId: number = 0,
        public roomTypeId: number = 0,
        public roomNumber: number = 0,
        public roomName: string = "",
        public length: number = 0,
        public width: number = 0,
        public area: number = 0,
        public height: number = 0,
        public floor: number = 0,
        public peopleAmount: number = 0,    
        public userId: number = 0 ){ }
}