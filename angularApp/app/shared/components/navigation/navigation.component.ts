import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../core/services/user.service';

@Component({
    selector: 'navigation',
    templateUrl: 'navigation.component.html'
})

export class NavigationComponent implements OnInit { 

    isLoggedIn: boolean = false;

    constructor(private userService: UserService){

    }

    ngOnInit(){
        this.isLoggedIn = this.userService.isLoggedIn();
        //console.log(this.isLoggedIn)
    }
}
