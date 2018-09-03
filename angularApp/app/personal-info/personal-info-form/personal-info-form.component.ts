import { Credentials } from './../../models/credentials';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../core/services/user.service';

@Component({
  selector: 'personal-info-form',
  templateUrl: './personal-info-form.component.html'
})
export class PersonalInfoFormComponent implements OnInit {

  credentials: Credentials = new Credentials();

  constructor(private userService: UserService) {
  }

  ngOnInit() {
    this.credentials = this.userService.getCurrentUser();
  }

}
