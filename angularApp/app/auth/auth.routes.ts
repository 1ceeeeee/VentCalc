
import { RouterModule, Routes } from '@angular/router';
import { AuthFormComponent } from './auth-form/auth-form.component';

const routes: Routes = [
    { path: '', component: AuthFormComponent }
];

export const AuthRoutes = RouterModule.forChild(routes);

