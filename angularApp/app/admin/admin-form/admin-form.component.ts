import { UserService } from './../../core/services/user.service';
import { User } from './../../models/user';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-form',
  templateUrl: './admin-form.component.html'  
})
export class AdminFormComponent implements OnInit {

  users:User [] = [];

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getAll()
      .subscribe(
        (result) => {
          this.users = result
        },
        (error) => {
          console.log(error)
        },
        ()=> {}
      )
  }

}
