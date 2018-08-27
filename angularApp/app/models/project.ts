import { CrudBase } from './CrudBase';
import { Room } from "./room";

export class Project extends CrudBase {
    public projectName: string = "";
    public rooms: Room[] = [];
}