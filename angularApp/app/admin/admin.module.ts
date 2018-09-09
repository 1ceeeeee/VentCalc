import { AdminRoutes } from './admin.routes';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminFormComponent } from './admin-form/admin-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SweetAlert2Module } from '@toverux/ngx-sweetalert2';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AdminRoutes,
    SweetAlert2Module
  ],
  declarations: [AdminFormComponent]
})
export class AdminModule { }
