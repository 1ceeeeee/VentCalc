import { CalculatorRoutes } from './calculator.routes';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CalculatorFormComponent } from './calculator-form/calculator-form.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    CalculatorRoutes,
    ReactiveFormsModule
  ],
  declarations: [CalculatorFormComponent]
})
export class CalculatorModule { }
