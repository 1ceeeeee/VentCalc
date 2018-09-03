import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CustomFooterComponent } from './components/customfooter/customfooter.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { AirexchangeFormComponent } from './../airexchange/airexchange-form/airexchange-form.component';
import { SpinnerFormComponent } from './components/spinner/spinner-form/spinner-form.component';
import { ChangePasswordFormComponent } from './components/change-password/change-password-form/change-password-form.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        ReactiveFormsModule
        
    ],

    declarations: [
        NavigationComponent,
        CustomFooterComponent,
        AirexchangeFormComponent,
        SpinnerFormComponent,
        ChangePasswordFormComponent
    ],

    exports: [
        NavigationComponent,
        CustomFooterComponent,
        AirexchangeFormComponent,
        SpinnerFormComponent,
        ChangePasswordFormComponent
    ]
})

export class SharedModule { }
