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

  constructor(private userService: UserService, private activatedRoute: ActivatedRoute) {
  }

  getUserById(id: string){
    console.log('fired_up_getUserById');
    this.userService.getUser(id)
    .subscribe(
      (data) => {
        this.user = data;
      },
      (error) => {
        console.log(error);
      },
      () => {}
    )
  }

  ngOnInit() {    

    this.activatedRoute.queryParams.subscribe(
      (param: any) => {
        this.userId = param['userId'];   
        if(this.userId !== null){
          this.credentials = this.userService.getCurrentUser();
          if(this.credentials.roles !== null && 
             this.credentials.roles.indexOf('Администратор') > -1){
            this.getUserById(this.userId);    
            this.isAdmin = true;    
          }else {
            this.isRestrictedAccess = true;
          }
        }
        else{
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
