import { UserService } from './../../core/services/user.service';
import { User } from './../../models/user';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-form',
  templateUrl: './admin-form.component.html'
})
export class AdminFormComponent implements OnInit {

  users: User[] = [];

  constructor(private userService: UserService, public router: Router) { }

  onDeleteUserClick(id: string) {
    this.userService.delete(id)
      .subscribe(
        () => { },
        (error) => {
          console.log(error);
        },
        () => {
          this.getAllUsers();
          console.log("user deleted");
        }
      )
  }

  editUser(id: string) {
    this.router.navigate(['/personal-info'], { queryParams: { userId: id } });
  }

  private getAllUsers() {
    this.userService.getAll()
      .subscribe(
        (data) => {
          this.users = data;
        },
        (error) => {
          console.log(error);
        },
        () => { }
      )
  }



  ngOnInit() {
    this.getAllUsers();
  }

}
