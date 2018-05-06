import { RouterModule, Routes } from '@angular/router';
import { AirexchangeFormComponent } from './airexchange-form/airexchange-form.component';

const routes: Routes = [
    { path: '', component: AirexchangeFormComponent }
];

export const AirexchangeRoutes = RouterModule.forChild(routes);

