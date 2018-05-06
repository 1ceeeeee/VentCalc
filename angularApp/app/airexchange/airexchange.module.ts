import { AirexchangeRoutes } from './airexchange.routes';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AirexchangeFormComponent } from './airexchange-form/airexchange-form.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  imports: [
    CommonModule,
    AirexchangeRoutes,
    ReactiveFormsModule    
  ],
  declarations: [AirexchangeFormComponent]  
})
export class AirexchangeModule { }
