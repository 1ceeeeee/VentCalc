import { CalculatorRoutes } from './calculator.routes';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CalculatorFormComponent } from './calculator-form/calculator-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SweetAlert2Module } from '@toverux/ngx-sweetalert2';

@NgModule({
  imports: [
    CommonModule,
    CalculatorRoutes,
    ReactiveFormsModule,
    SweetAlert2Module
  ],
  declarations: [CalculatorFormComponent]  
})
export class CalculatorModule { }
