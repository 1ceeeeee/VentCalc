import { Injectable, isDevMode } from '@angular/core';

@Injectable()
export class Configuration {

    public Server: string = "";

    constructor() {
        if(isDevMode())        
            this.Server = 'http://localhost:5000/';
        else
            this.Server =  'http://[2a02:2168:840a:ef00:6180:df25:f49e:b4f5]/';//'https://vent-calc.herokuapp.com/'; //'http://localhost:5000/';//
    }
    
}
