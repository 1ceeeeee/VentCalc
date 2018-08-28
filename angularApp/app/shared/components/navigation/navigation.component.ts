import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../core/services/user.service';


@Component({
    selector: 'navigation',
    templateUrl: 'navigation.component.html'
})

export class NavigationComponent implements OnInit { 

    isLoggedIn: boolean = false;
    //subscription: any;

    constructor(private userService: UserService){

    }

    ngOnInit(){        
        this.userService.authNavStatus$.subscribe(status => this.isLoggedIn = status);        
    }

}
