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
  user: UserWithRoles = new UserWithRoles();
  userId: string = "";

  constructor(private userService: UserService, private activatedRoute: ActivatedRoute) {
  }

  getUser(id: string){
    console.log('fired_up_getUser');
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
        this.getUser(this.userId);        
        //this.form.get('userName')!.setValue(param['userName']);          
      }
    );

    this.getUser(this.userId);
    console.log(this.user);
    this.credentials = this.userService.getCurrentUser();    
    
  }

}
