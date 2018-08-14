import { UserService } from './../../core/services/user.service';
import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user';
import { FormGroup, FormControl, Validators } from '../../../../node_modules/@angular/forms';

@Component({
  selector: 'registration-form',
  templateUrl: './registration-form.component.html'
})
export class RegistrationFormComponent implements OnInit {

  user: User = new User();

  form = new FormGroup({
    user: new FormGroup({
      email: new FormControl('', Validators.required),
      firstName: new FormControl('', Validators.required),
      middleName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required)      
    })
  });

  constructor(public userService: UserService) { }

  get email() {
    return this.form.get('user.email')!;
  }

  get firstName() {
    return this.form.get('user.firstName')!;
  }

  get middleName() {
    return this.form.get('user.middleName')!;
  }

  get lastName() {
    return this.form.get('user.lastName')!;
  }

  get password() {
    return this.form.get('user.password')!;
  }

  onCreateUserClick(){
    
    console.log(this.email.value, + ' ' + this.firstName.value + ' ' + this.middleName.value + ' ' + this.lastName.value + ' ' + this.password.value);
    var usr = new User(
      0,
      this.firstName.value,
      this.middleName.value,
      this.lastName.value,
      this.email.value,
      this.password.value,
      this.email.value
    );

    this.userService.Create(usr)
    .subscribe(
      () => {
        console.log(usr);        
      },
      (error) => {
        console.log(error)
      }
    );
  }

  ngOnInit() {
  }

}
