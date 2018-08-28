import { UserService } from './../services/user.service';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private userService: UserService){}

  canActivate(){
    if(!this.userService.isTokenExpired()){
      return true;
    }
    this.router.navigate(['/auth']);
    return false;
  }
}
