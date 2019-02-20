import { BaseService } from './base.service';
import { Project } from './../../models/project';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Configuration } from '../../app.constants';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ProjectService extends BaseService {

  private actionUrl: string;
  private updateUrl: string;

  constructor(private http: HttpClient, configuration: Configuration) {
    super();
    this.actionUrl = configuration.Server + 'api/projects/';
    this.updateUrl = configuration.Server + 'api/projects/updateproject';
  }

  Add(project: Project): Observable<Project> {
    // let headers = this.headers;
    // headers = headers.append('Authorization', `Bearer ${this.getToken()}`);
    return this.http.post<Project>(this.actionUrl, project, { headers: this.authHeaders });
  }

  getById(id: number): Observable<Project> {
    return this.http.get<Project>(this.actionUrl + id, { headers: this.authHeaders });
  }
  getAll(): Observable<Project[]> {
    return this.http.get<Project[]>(this.actionUrl, { headers: this.authHeaders })
  }

  getAllByUserId(currentUserId: string): Observable<Project[]> {
    return this.http.get<Project[]>(this.actionUrl + 'getallbyuserId/' + currentUserId, { headers: this.authHeaders });
  }

  delete(id: number): Observable<Project> {
    return this.http.delete<Project>(this.actionUrl + id, { headers: this.authHeaders });
  }

  update(project: Project): Observable<Project> {
    return this.http.put<Project>(this.updateUrl, project, { headers: this.authHeaders });
  }
}
