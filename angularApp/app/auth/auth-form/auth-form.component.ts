import { UserService } from './../../core/services/user.service';
import { Credentials } from './../../models/credentials';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ADMIN_ROLE } from '../../app.constants';

@Component({
  selector: 'auth-form',
  templateUrl: './auth-form.component.html'
})
export class AuthFormComponent implements OnInit {

  constructor(private userService: UserService, private router: Router, private activatedRoute: ActivatedRoute) { }
    
  brandNew: boolean = false;
  isRequesting: boolean = false;
  isLoggedIn: boolean = false;  
  errors: string[] = [];

  get userName() {
    return this.form.get('userName')!;
  }

  get password() {
    return this.form.get('password')!;
  }

  form = new FormGroup({
    userName: new FormControl('', Validators.compose([
      Validators.required,
      Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
    ])),
    password: new FormControl('', Validators.compose([
      Validators.required,
      Validators.minLength(6)
    ]))
  })

  onLoginClick() {
    
    var cred = new Credentials(
      this.userName.value,
      this.password.value
    );
    this.isRequesting = true;    
    this.userService.login(cred)    
      .subscribe(
        (result) => {
          if (result) {
            this.userService.storeCurrentUser(result);
            this.router.navigate(['/home']);
          }
        },
        (errors) => {          
          this.errors = errors.error!.item2!;  
          this.isRequesting = false;         
        },
        () => {
          this.isLoggedIn = true;
          this.userService.changeAuthNavStatus(true);
          this.userService.changeAuthNavUserName(this.userService.getCurrentUser().userName);
          this.userService.changeAuthAdminNavStatus(this.userService.isAdmin(ADMIN_ROLE))
          this.isRequesting = false;          
        }
      );
  }

  ngOnInit() {

    this.activatedRoute.queryParams.subscribe(
      (param: any) => {
        this.brandNew = param['brandNew'];
        this.form.get('userName')!.setValue(param['userName']);        
      }
    );
    
  }

}
