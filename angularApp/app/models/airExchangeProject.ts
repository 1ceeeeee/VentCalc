import { AirExchangeRoom } from './airExchangeRoom';
export class AirExchangeProject {
    constructor(
        public id: number = 0,
        public inflowTotal: number = 0,
        public exhaustTotal: number = 0,
        public airExchangeRooms: AirExchangeRoom[] = []) { }
}