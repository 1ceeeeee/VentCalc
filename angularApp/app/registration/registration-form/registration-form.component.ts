import { UserService } from './../../core/services/user.service';
import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user';
import { FormGroup, FormControl, Validators } from '../../../../node_modules/@angular/forms';
import { PasswordValidator } from '../../core/validators/password.validator';
import { Router } from '@angular/router';

@Component({
  selector: 'registration-form',
  templateUrl: './registration-form.component.html'
})
export class RegistrationFormComponent implements OnInit {

  // user: User = new User();
  isRequesting: boolean = false;
  errors: string[] = [];

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
    return this.form.get('passwordForm.password')!;
  }

  get repeatPassword() {
    return this.form.get('passwordForm.repeatPassword')!;
  }

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
      ]))
    }),

    passwordForm: new FormGroup({
      password: new FormControl('', Validators.compose([
        Validators.required,
        Validators.minLength(6)
      ])),
      repeatPassword: new FormControl('', Validators.compose([
        Validators.required,
        Validators.minLength(6)        
      ]))
    },{
      validators: PasswordValidator.validate.bind(this)
    })

  });

  constructor(public userService: UserService, public router:Router) { }

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

    this.isRequesting = true;
    this.userService.register(usr)
      .subscribe(
        (result) => {
          if(result){
            console.log(usr.email);
            this.router.navigate(['/auth'], {queryParams: {brandNew: true, userName: usr.email}});
          }
        },
        (errors) => {
          this.errors = errors.error;
          this.isRequesting = false;
        },
        () => {
          this.isRequesting = false;
        }
      );
  }

  ngOnInit() {
  }

}
