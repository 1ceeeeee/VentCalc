import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    { path: '', component: RegistrationFormComponent }
];

export const RegistrationRoutes = RouterModule.forChild(routes);

