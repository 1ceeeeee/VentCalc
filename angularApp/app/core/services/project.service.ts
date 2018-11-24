import { Project } from './../../models/project';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Configuration } from '../../app.constants';
import { Observable } from 'rxjs/Observable';
import { TOKEN_NAME } from './user.service';


@Injectable()
export class ProjectService {

  private headers: HttpHeaders;
  private actionUrl: string;
  private updateUrl: string;

  constructor(private http: HttpClient, configuration: Configuration) {
    this.actionUrl = configuration.Server + 'api/projects/';
    this.updateUrl = configuration.Server + 'api/projects/updateproject';

    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');
  }

  Add(project: Project): Observable<Project> {
    let headers = this.headers;
    headers = headers.append('Authorization', `Bearer ${this.getToken()}`);
    return this.http.post<Project>(this.actionUrl, project, { headers: headers });
  }

  getById(id: number): Observable<Project>{
    let headers = this.headers;        
    headers = headers.append('Authorization', `Bearer ${this.getToken()}`);
    return this.http.get<Project>(this.actionUrl + id, {headers: headers});
  }

  getAllByUserId(currentUserId: string): Observable<Project[]> {
    let headers = this.headers;
    headers = headers.append('Authorization', `Bearer ${this.getToken()}`);
    return this.http.get<Project[]>(this.actionUrl + 'getallbyuserId/' + currentUserId, { headers: headers });
  }

  delete(id: number): Observable<Project> {
    let headers = this.headers;
    headers = headers.append('Authorization', `Bearer ${this.getToken()}`);
    return this.http.delete<Project>(this.actionUrl + id, { headers: headers });
  }

  update(project: Project): Observable<Project> {
    let headers = this.headers;
    headers = headers.append('Authorization', `Bearer ${this.getToken()}`);
    return this.http.put<Project>(this.updateUrl, project, { headers: headers });
  }

  getToken(): string | null {
    return localStorage.getItem(TOKEN_NAME);
  }

}
