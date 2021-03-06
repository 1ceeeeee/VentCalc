import { HeatingFormComponent } from './../heating/heating-form/heating-form.component';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CustomFooterComponent } from './components/customfooter/customfooter.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { AirexchangeFormComponent } from './../airexchange/airexchange-form/airexchange-form.component';
import { SpinnerFormComponent } from './components/spinner/spinner-form/spinner-form.component';
import { ChangePasswordFormComponent } from './components/change-password/change-password-form/change-password-form.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';


@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        ReactiveFormsModule,
        FormsModule
        
    ],

    declarations: [
        NavigationComponent,
        CustomFooterComponent,
        AirexchangeFormComponent,
        HeatingFormComponent,
        SpinnerFormComponent,
        ChangePasswordFormComponent
    ],

    exports: [
        NavigationComponent,
        CustomFooterComponent,
        AirexchangeFormComponent,
        HeatingFormComponent,
        SpinnerFormComponent,
        ChangePasswordFormComponent
    ]
})

export class SharedModule { }
