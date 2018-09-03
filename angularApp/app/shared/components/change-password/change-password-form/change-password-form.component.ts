import { Credentials } from './../../../../models/credentials';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../../core/services/user.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'change-password-form',
  templateUrl: './change-password-form.component.html'
})
export class ChangePasswordFormComponent implements OnInit {

  credentials: Credentials = new Credentials();
  isRequesting: boolean = false;
  // errors: string[] = [];

  constructor(private userService: UserService) { }

  form = new FormGroup({
    oldPassword: new FormControl('', Validators.compose([
      Validators.required,
      Validators.minLength(6)
    ])),
    newPassword: new FormControl('', Validators.compose([
      Validators.required,
      Validators.minLength(6)
    ]))
  }
  // , {
  //     validators: PasswordValidator.validate.bind(this)
  //   }
  );

  get newPassword() {
    return this.form.get('newPassword')!;
  }

  get oldPassword() {
    return this.form.get('oldPassword')!;
  }

  onChangePasswordClick(){
    this.isRequesting = true;
  }

  ngOnInit() {
    this.credentials = this.userService.getCurrentUser();
  }

}
