import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../core/services/user.service';


@Component({
    selector: 'navigation',
    templateUrl: 'navigation.component.html'
})

export class NavigationComponent implements OnInit { 

    isLoggedIn: boolean = false;
    userName: string = "";    

    constructor(private userService: UserService){

    }

    logout(){
        this.userService.logout();
    }

    ngOnInit(){        
        this.userService.authNavStatus$.subscribe(status => this.isLoggedIn = status); 
        this.userService._authNavUserName$.subscribe(userName => this.userName = userName);
        //this.userName = this.userService.getCurrentUser().userName;       
    }

}
