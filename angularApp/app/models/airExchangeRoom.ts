export class AirExchangeRoom {
    constructor(
        public id: number = 0,
        public roomNumber: number = 0,
        public roomName: string = "",
        public tempIn: number = 0,
        public area: number = 0,
        public volume: number = 0,
        public peopleAmount: number = 0,
        public inflow: number = 0,
        public exhaust: number = 0,
        public inflowCalc: number = 0,
        public exhaustCalc: number = 0) { }
}