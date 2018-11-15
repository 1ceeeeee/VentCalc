import { ProjectsFormComponent } from './projects-form/projects-form.component';

import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    { path: '', component: ProjectsFormComponent }
];

export const ProjectsRoutes = RouterModule.forChild(routes);

