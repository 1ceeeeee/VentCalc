import { ActivatedRoute } from '@angular/router';
import { Credentials } from './../../models/credentials';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../core/services/user.service';
import { UserWithRoles } from '../../models/userWithRoles';

@Component({
  selector: 'personal-info-form',
  templateUrl: './personal-info-form.component.html'
})
export class PersonalInfoFormComponent implements OnInit {

  credentials: Credentials = new Credentials();
  selectedUserCredentials: Credentials = new Credentials();
  user: UserWithRoles = new UserWithRoles();
  userId: string = "";
  currentUserId: string = "";
  isAdmin: boolean = false;
  isRestrictedAccess: boolean = false;
  selectedRoles: string[] = [];
  isRequesting: boolean = false;

  constructor(private userService: UserService, private activatedRoute: ActivatedRoute) {
  }

  getUserById(id: string) {    
    this.userService.getUser(id)
      .subscribe(
        (data) => {
          this.user = data;
        },
        (error) => {
          console.log(error);
        },
        () => { }
      )
  }

  onChange(role: string) {    
    let index = this.user.userRoles.indexOf(role);
    if (index == -1) {      
      this.user.userRoles.push(role);
    } else {      
      this.user.userRoles.splice(index,1);
    }    
    console.log(this.user.userRoles);
  }

  onSave() {
    this.isRequesting = true;
    // this.user.userRoles = this.selectedRoles;
    console.log(this.user);
    this.userService.editUserRoles(this.user)
      .subscribe(
        (result) => {
          if (result) {
            console.log('Roles changed');
          }
        },
        (error) => {
          console.log(error);
        },
        () => {
          this.isRequesting = false;        
        }
      )
  }

  ngOnInit() {

    this.activatedRoute.queryParams.subscribe(
      (param: any) => {
        this.userId = param['userId'];
        if (this.userId) {
          console.log('userId is not null');
          this.credentials = this.userService.getCurrentUser();
          if (this.credentials.roles !== null &&
            this.credentials.roles.indexOf('Администратор') > -1) {
            this.getUserById(this.userId);
            this.isAdmin = true;
          } else {
            this.isRestrictedAccess = true;
          }
        }
        else {
          this.userId = this.userService.getCurrentUser().id;
        }

        //this.form.get('userName')!.setValue(param['userName']);          
      }
    );

    this.currentUserId = this.userService.getCurrentUser().id;
    //this.getUser(this.userId);
    //console.log(this.user);

    //console.log(this.credentials);

  }

}
