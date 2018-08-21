import { UserService } from './../../core/services/user.service';
import { Credentials } from './../../models/credentials';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'auth-form',
  templateUrl: './auth-form.component.html'
})
export class AuthFormComponent implements OnInit {

  constructor(private userService: UserService, private router: Router, private activatedRoute: ActivatedRoute) { }

  // subscription: any = null;
  credentials: Credentials = new Credentials();
  brandNew: boolean = false;
  // isRequesting: boolean;
  submitted: boolean = true;
  errors: string[] = [];

  get userName() {
    return this.form.get('userName')!;
  }

  get password() {
    return this.form.get('password')!;
  }

  form = new FormGroup({
    userName: new FormControl('123', Validators.compose([
      Validators.required,
      Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
    ])),
    password: new FormControl('', Validators.compose([
      Validators.required,
      Validators.minLength(6)
    ]))
  })

  onLoginClick() {
    // var cred = new Credentials(
    //   this.userName.value,
    //   this.password.value
    // )

    this.credentials.userName = this.userName.value;
    this.credentials.password = this.password.value;

    this.userService.login(this.credentials)
      .subscribe(
        (result) => {
          if (result) {
            this.router.navigate(['/home']);
          }
        },
        (errors) => {          
          this.errors = errors.error.item2;          
        }
      );
  }

  ngOnInit() {

    this.activatedRoute.queryParams.subscribe(
      (param: any) => {
        this.brandNew = param['brandNew'];
        this.credentials.userName = param['userName'];
      }
    );
    this.form.get('userName')!.setValue(this.credentials.userName);
  }

  // ngOnDestroy() {
  //   this.subscription.unsubscribe();
  // }

}
