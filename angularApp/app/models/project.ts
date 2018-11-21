import { CrudBase } from './CrudBase';
import { Room } from "./room";

export class Project extends CrudBase {
    public projectName: string = "";
    public cityId: number = 0;
    public rooms: Room[] = [];
}