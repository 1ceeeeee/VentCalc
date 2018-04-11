import { RoomService } from './services/room.service';
import { BuildingKindService } from './services/building-kind.service';
import { CommonModule } from '@angular/common';
import { ModuleWithProviders, NgModule } from '@angular/core';
import { Configuration } from '../app.constants';
import { ThingService } from './services/thing-data.service';
import { BuildingTypeService } from './services/building-type.service';
import { CityService } from './services/city.service';
import { RoomTypeService } from './services/room-type.service';
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
                CityService,
                // DataService,
                BuildingTypeService,
                BuildingKindService,
                RoomService,
                RoomTypeService,
                Configuration
            ]
        };
    }
}
