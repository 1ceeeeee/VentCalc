import { GeographyService } from './services/geography.service';
import { CommonModule } from '@angular/common';
import { ModuleWithProviders, NgModule } from '@angular/core';

import { Configuration } from '../app.constants';
import { ThingService } from './services/thing-data.service';
import { BuildingTypeService } from './services/building-type.service';
// import { DataService } from './services/data.service';

@NgModule({
    imports: [
        CommonModule
    ]
})

export class CoreModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: CoreModule,
            providers: [
                ThingService,                
                GeographyService,
                // DataService,
                BuildingTypeService,
                Configuration
            ]
        };
    }
}
