import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeatingFormComponent } from './heating-form/heating-form.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule
  ],
  declarations: [HeatingFormComponent]
})
export class HeatingModule { }
