import { RegistrationRoutes } from './registration.routes';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { ReactiveFormsModule } from '../../../node_modules/@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RegistrationRoutes
  ],
  declarations: [RegistrationFormComponent]
})
export class RegistrationModule { }
