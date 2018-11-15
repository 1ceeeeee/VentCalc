import { SweetAlert2Module } from '@toverux/ngx-sweetalert2';
import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectsFormComponent } from './projects-form/projects-form.component';
import { ProjectsRoutes } from './projects.routes';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SweetAlert2Module,
    ProjectsRoutes
  ],
  declarations: [ProjectsFormComponent]
})
export class ProjectsModule { }
