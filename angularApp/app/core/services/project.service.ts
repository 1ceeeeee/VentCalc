import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Configuration } from '../../app.constants';
import { Observable } from 'rxjs/Observable';
import { Project } from '../../models/project';


@Injectable()
export class ProjectService {

  private headers: HttpHeaders;
  private actionUrl: string;

  constructor(private http: HttpClient, configuration: Configuration) {
    this.actionUrl = configuration.Server + 'api/projects/';

    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');
  }

  Add(project: Project): Observable<Project> {
    console.log(project);
    return this.http.post<Project>(this.actionUrl, project, { headers: this.headers });
  }

}
