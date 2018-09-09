import { RouterModule, Routes } from '@angular/router';
import { AdminFormComponent } from './admin-form/admin-form.component';



const routes: Routes = [
    { path: '', component: AdminFormComponent }
];

export const AdminRoutes = RouterModule.forChild(routes);

