import { UserService } from './user.service';
import { Injectable } from '@angular/core';
import { Router, ActivatedRouteSnapshot } from '@angular/router';

@Injectable()
export class RoleGuardService {

  constructor(public userService: UserService, public router: Router) { }

  canActivate(route: ActivatedRouteSnapshot): boolean {

     if(!this.userService.isAdmin(route.data.expectedRole)){
      this.router.navigate(['/auth']);
      return false;
     }

     return true;
  }
}
