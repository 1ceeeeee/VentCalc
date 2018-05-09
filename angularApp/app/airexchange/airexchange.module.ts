import { SharedModule } from './../shared/shared.module';
import { AirexchangeRoutes } from './airexchange.routes';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  imports: [
    CommonModule,
    AirexchangeRoutes,
    ReactiveFormsModule,
    SharedModule   
  ],
  declarations: []  
})
export class AirexchangeModule { }
