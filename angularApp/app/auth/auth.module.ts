import { AuthRoutes } from './auth.routes';
import { AuthFormComponent } from './auth-form/auth-form.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AuthRoutes,
    SharedModule
  ],
  declarations: [AuthFormComponent]
})
export class AuthModule { }
