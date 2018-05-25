import { SharedModule } from './../shared/shared.module';
import { CalculatorRoutes } from './calculator.routes';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CalculatorFormComponent } from './calculator-form/calculator-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SweetAlert2Module } from '@toverux/ngx-sweetalert2';
import { NgxSelectModule } from 'ngx-select-ex';

@NgModule({
  imports: [
    CommonModule,
    CalculatorRoutes,
    ReactiveFormsModule,
    SweetAlert2Module,
    SharedModule,
    NgxSelectModule
  ],
  declarations: [CalculatorFormComponent]  
})
export class CalculatorModule { }
