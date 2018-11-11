import { Injectable, isDevMode } from '@angular/core';

export const ADMIN_ROLE: string = 'Администратор';

@Injectable()
export class Configuration {

    public Server: string = "";    

    constructor() {
        if(isDevMode())        
            this.Server = 'http://localhost:5000/';
        else
            this.Server =  'http://178.140.207.131:8081/';//'https://vent-calc.herokuapp.com/'; //'http://localhost:5000/';//
    }
    
}
