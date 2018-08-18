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
  errors: string[] = [];

  form = new FormGroup({
    user: new FormGroup({
      email: new FormControl('', Validators.compose([
        Validators.required,
        Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
      ])),
      firstName: new FormControl('', Validators.compose([
        Validators.pattern('^[А-Яа-я]+$')
      ])),
      middleName: new FormControl('', Validators.compose([
        Validators.pattern('^[А-Яа-я]+$')
      ])),
      lastName: new FormControl('', Validators.compose([
        Validators.pattern('^[А-Яа-я]+$')
      ])),
      password: new FormControl('', Validators.compose([
        Validators.required,
        Validators.minLength(6)
      ])),
      passwordCheck: new FormControl('', Validators.compose([
        Validators.required,
        Validators.minLength(6)
      ]))
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

  get passwordCheck() {
    return this.form.get('user.passwordCheck')!;
  }

  onCreateUserClick() {

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
        },
        (errors) => {
          this.errors = errors.error;
          console.log(this.errors);
          console.log(this.errors.length);
        }
      );
  }

  ngOnInit() {
  }

}
