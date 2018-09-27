import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonalInfoFormComponent } from './personal-info-form/personal-info-form.component';
import { PersonalInfoRoutes } from './personal-info.routes';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { SweetAlert2Module } from '@toverux/ngx-sweetalert2';

@NgModule({
  imports: [
    CommonModule,
    PersonalInfoRoutes,
    ReactiveFormsModule,
    SharedModule,
    SweetAlert2Module
  ],
  declarations: [PersonalInfoFormComponent]
})
export class PersonalInfoModule { }
