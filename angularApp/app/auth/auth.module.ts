import { AuthRoutes } from './auth.routes';
import { AuthFormComponent } from './auth-form/auth-form.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AuthRoutes
  ],
  declarations: [AuthFormComponent]
})
export class AuthModule { }
