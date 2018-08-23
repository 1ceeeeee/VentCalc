import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CustomFooterComponent } from './components/customfooter/customfooter.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { AirexchangeFormComponent } from './../airexchange/airexchange-form/airexchange-form.component';
import { SpinnerFormComponent } from './components/spinner/spinner-form/spinner-form.component';

@NgModule({
    imports: [
        CommonModule,
        RouterModule
    ],

    declarations: [
        NavigationComponent,
        CustomFooterComponent,
        AirexchangeFormComponent,
        SpinnerFormComponent
    ],

    exports: [
        NavigationComponent,
        CustomFooterComponent,
        AirexchangeFormComponent,
        SpinnerFormComponent
    ]
})

export class SharedModule { }
