import { TOKEN_NAME } from "./user.service";
import { HttpHeaders } from "@angular/common/http";

export class BaseService {
    public headers: HttpHeaders;
    public authHeaders: HttpHeaders;

    constructor() {
        this.headers = new HttpHeaders();
        this.headers = this.headers.set('Content-Type', 'application/json');
        this.headers = this.headers.set('Accept', 'application/json');

        this.authHeaders = new HttpHeaders();
        this.authHeaders = this.headers;
        this.authHeaders = this.authHeaders.append('Authorization', `Bearer ${this.getToken()}`);
    }

    getToken(): string | null {
        console.log('BaseService');
        return localStorage.getItem(TOKEN_NAME);
    }
}