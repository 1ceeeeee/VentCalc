import { Injectable, isDevMode } from '@angular/core';

@Injectable()
export class Configuration {

    public Server: string = "";

    constructor() {
        if(isDevMode())        
            this.Server = 'http://localhost:5000/';
        else
            this.Server = 'https://vent-calc.herokuapp.com/';
    }
    
}
