import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { SweetAlert2Module } from '@toverux/ngx-sweetalert2';
import { AppComponent } from './app.component';
import { AppRoutes } from './app.routes';
import { CoreModule } from './core/core.module';
import { HomeModule } from './home/home.module';
import { SharedModule } from './shared/shared.module';

@NgModule({
    imports: [
        BrowserModule,
        AppRoutes,
        SharedModule,
        CoreModule.forRoot(),
        HomeModule,
        SweetAlert2Module.forRoot({
            buttonsStyling: true,
            customClass: 'modal-content',
            confirmButtonClass: 'btn btn-primary',
            cancelButtonClass: 'btn btn-danger',
            confirmButtonText: 'Да',
            cancelButtonText: 'Отмена'
        })
    ],

    declarations: [
        AppComponent        
    ],

    bootstrap: [AppComponent]
})

export class AppModule { }
