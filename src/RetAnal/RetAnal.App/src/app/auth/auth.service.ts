import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {JwtHelperService} from "@auth0/angular-jwt";
import {Observable} from "rxjs";

export interface LoginResponse {
  token: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private jwtHelper: JwtHelperService;

  constructor(private http: HttpClient, private router: Router) {
    this.jwtHelper = new JwtHelperService();
  }

  public login(username: string, password: string): Observable<LoginResponse> {
    const url = `/api/auth/login?username=${username}&password=${password}`;
    return this.http.post<LoginResponse>(url, {});
  }

  public logout() {
    localStorage.removeItem('jwt');
    this.router.navigate(['login']);
  }

  public setToken(token: string): void {
    localStorage.setItem('jwt', token);
  }

  public get isAuthenticated(): boolean {
    const token = this.token;

    return token !== null && !this.jwtHelper.isTokenExpired(token);
  }

  public get isAdministrator(): boolean {
    const token = this.token;
    if (!token) return false;

    const role = this.jwtHelper.decodeToken(token).role;
    return role === "Administrator";
  }

  public get username(): string | null {
    const token = this.token;
    if (!token) return null;

    return this.jwtHelper.decodeToken(token).unique_name;
  }

  private get token(): string | null {
    return localStorage.getItem('jwt');
  }
}
