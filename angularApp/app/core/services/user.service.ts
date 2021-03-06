import { BaseService } from './base.service';
import { UserWithRoles } from './../../models/userWithRoles';
import { User } from './../../models/user';
import { ChangePassword } from './../../models/changePassword';
import { Credentials } from './../../models/credentials';
import { Injectable } from '@angular/core';
import { HttpClient } from '../../../../node_modules/@angular/common/http';
import { Configuration, ADMIN_ROLE } from '../../app.constants';
import { Observable } from '../../../../node_modules/rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import * as jwt_decode from 'jwt-decode';


export const TOKEN_NAME: string = 'currentUser_auth_token';
export const USER_ID: string = 'currentUser_id';
export const USER_NAME: string = 'currentUser_name';


@Injectable()
export class UserService extends BaseService {

  private actionUrlAuth: string;
  private actionUrlReg: string;
  private actionUrlChangePwd: string;
  private actionUrlChangePwdHash: string;
  private actionUrlEditUserRoles: string;  
  private loggedIn: boolean = false;  

  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  authNavStatus$ = this._authNavStatusSource.asObservable();

  private _authNavUserName = new BehaviorSubject<string>('');
  _authNavUserName$ = this._authNavUserName.asObservable();

  private _authAdminNavStatusSource = new BehaviorSubject<boolean>(false);
  authAdminNavStatus$ = this._authAdminNavStatusSource.asObservable();
  

  constructor(private http: HttpClient, configuration: Configuration) {
    super();
    this.actionUrlAuth = configuration.Server + 'api/auth/';
    this.actionUrlReg = configuration.Server + 'api/accounts/';    
    this.actionUrlChangePwd = configuration.Server + 'api/accounts/changepwd';
    this.actionUrlChangePwdHash = configuration.Server + 'api/accounts/changepwdhash';
    this.actionUrlEditUserRoles = configuration.Server + 'api/accounts/editroles';    

    this.loggedIn = !this.isTokenExpired();
    this._authNavStatusSource.next(this.loggedIn);
    
    this._authAdminNavStatusSource.next(this.isAdmin(ADMIN_ROLE));    
    this._authNavUserName.next(this.getCurrentUser().userName);
  }

  register(user: User): Observable<User> {
    return this.http.post<User>(this.actionUrlReg, user, { headers: this.headers });
  }

  delete(id: string): Observable<any> {
    return this.http.delete<any>(this.actionUrlReg + id, { headers: this.headers });
  }

  login(credentials: Credentials) {
    return this.http.post<Credentials>(this.actionUrlAuth, credentials, { headers: this.headers });
  }

  logout() {
    localStorage.removeItem(TOKEN_NAME);
    localStorage.removeItem(USER_ID);
    localStorage.removeItem(USER_NAME);
    this.loggedIn = false;
    this._authNavStatusSource.next(this.loggedIn);
    this._authNavUserName.next('');
  }

  changePassword(pwd: ChangePassword): Observable<ChangePassword> {
    return this.http.post<ChangePassword>(this.actionUrlChangePwd, pwd, { headers: this.headers });
  }

  changePasswordHash(pwd: ChangePassword): Observable<ChangePassword> {    
    return this.http.post<ChangePassword>(this.actionUrlChangePwdHash, pwd, {headers: this.authHeaders});
  }

  getAll(): Observable<User[]> {
    return this.http.get<User[]>(this.actionUrlReg, { headers: this.headers });
  }

  getUser(id: string): Observable<UserWithRoles>{
    return this.http.get<UserWithRoles>(this.actionUrlReg + id, {headers: this.headers});
  }

  editUserRoles(userWithRoles: UserWithRoles): Observable<UserWithRoles>{         
    return this.http.post<UserWithRoles>(this.actionUrlEditUserRoles, userWithRoles, {headers: this.authHeaders})
  }

  storeCurrentUser(credentials: Credentials) {
    localStorage.setItem(TOKEN_NAME, credentials.auth_token);
    localStorage.setItem(USER_ID, credentials.id);
    localStorage.setItem(USER_NAME, credentials.userName);
  }

  getCurrentUser(): Credentials {
    return new Credentials(
      localStorage.getItem(USER_NAME)!,
      "",
      localStorage.getItem(TOKEN_NAME)!,
      0,
      localStorage.getItem(USER_ID)!,
      this.getUserRoles()!
    );
  }

  isLoggedIn() {
    return this.loggedIn;
  }

  isAdmin(expectedRole: string){    
    if (this.isTokenExpired()) {      
      return false;
    }    
    let token = this.getToken();   
    var roles = this.getUserRoles(token);

    if(roles.indexOf(expectedRole) === -1){      
      return false;
    }

    return true;
  }

  setToken(token: string): void {
    localStorage.setItem(TOKEN_NAME, token);
  }

  getTokenExpirationDate(token: string): Date | null {
    var decoded: any = jwt_decode(token);

    if (decoded.exp === undefined) return null;

    var date = new Date(0);
    date.setUTCSeconds(decoded.exp);
    return date;
  }

  getTokenUserRoles(token: string): string[]{
    var decoded: any = jwt_decode(token);
    var roles = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role';
    if (decoded[roles] === undefined) return [];
    return decoded[roles];
  }

  isTokenExpired(token?: string | null): boolean {
    if (!token) token = this.getToken();
    if (!token) return true;

    const date = this.getTokenExpirationDate(token);
    if (date === undefined || date === null) {
      return false;
    }
    return !(date.valueOf() > new Date().valueOf());
  }

  getUserRoles(token?: string | null): string[] {
    if (!token) token = this.getToken();
    if (!token) return [];
    return this.getTokenUserRoles(token);    
  }

  changeAuthNavStatus(currentStatus: boolean) {
    this._authNavStatusSource.next(currentStatus)
  }

  changeAuthNavUserName(currentUserName: string) {
    this._authNavUserName.next(currentUserName);
  }

  changeAuthAdminNavStatus(currentStatus: boolean){
    this._authAdminNavStatusSource.next(currentStatus);
  }

}
