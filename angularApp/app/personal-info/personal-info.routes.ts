
import { RouterModule, Routes } from '@angular/router';
import { PersonalInfoFormComponent } from './personal-info-form/personal-info-form.component';

const routes: Routes = [
    { path: '', component: PersonalInfoFormComponent }
];

export const PersonalInfoRoutes = RouterModule.forChild(routes);

