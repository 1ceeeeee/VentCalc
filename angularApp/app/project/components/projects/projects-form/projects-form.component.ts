import { ProjectService } from './../../../../core/services/project.service';
import { Project } from './../../../../models/project';
import { Credentials } from './../../../../models/credentials';
import { UserService } from './../../../../core/services/user.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'projects-form',
  templateUrl: './projects-form.component.html',
})
export class ProjectsFormComponent implements OnInit {

  currentUser: Credentials = new Credentials();
  projects: Project[] = [];
  selectedProject: Project = new Project();
  error: string = "";

  form = new FormGroup({
    projectName: new FormControl('', Validators.required)
  });

  constructor(private userService: UserService, private projectService: ProjectService, public router: Router) { }

  get projectName() {
    return this.form.get('projectName')!;
  }

  getUserProjects() {
    this.projectService.getAllByUserId(this.currentUser.id)
      .subscribe(
        (data) => {
          this.projects = data;
          console.log(data);
        },
        (error) => {
          this.error = error;
        },
        () => { }
      )
  }

  onSaveProject() {
    let project = new Project();
    project.createUserId = this.currentUser.id;
    project.projectName = this.projectName.value!;

    if (this.selectedProject)
      project.id = this.selectedProject.id;
    else
      project.id = 0;


    if (project.id === 0)
      this.projectService.Add(project)
        .subscribe(
          (data) => {
            console.log('in add');
            this.projects.push(data);
          },
          (error) => {
            this.error = error;
          },
          () => { return; }
        );

    this.projectService.update(project)
      .subscribe(
        () => {
          console.log('in update, projectName: ' + project.projectName);
          this.getUserProjects();
        },
        (error) => {
          this.error = error;
        },
        () => { }
      )


  }

  onDeleteProject(id: number) {
    this.projects.filter(x => x.id != id);
    this.projectService.delete(id)
      .subscribe(
        () => {
          this.getUserProjects();
        },
        (error) => {
          console.log(error);
        }
      )
  }

  onEditProject(id: number){
    this.router.navigate(['/calculator'], { queryParams: { projectId: id } });
  }

  // onEditProject(id: number) {
  //   this.selectedProject = this.projects.filter(x => x.id == id)[0];
  //   if (!this.selectedProject)
  //     return;
  //   this.form.get('projectName')!
  //     .setValue(this.selectedProject.projectName);
  // }

  onOpenProject(id: number){
    this.router.navigate(['/calculator'], { queryParams: { projectId: id } });
  }

  ngOnInit() {
    this.currentUser = this.userService.getCurrentUser();
    this.getUserProjects();
  }

}
