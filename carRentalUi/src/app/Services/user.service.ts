import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from '../models/models';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  readonly url = 'https://localhost:7166/';
  private userPayload: any;
  constructor(private http: HttpClient) {
    this.userPayload = this.decodedToken;
  }

  login(loginData: Login) {
    return this.http.post(this.url + 'api/User/LoginUser', loginData, {
      responseType: 'text',
    });
  }

  decodedToken() {
    const jwtHelper = new JwtHelperService();
    const token = this.getToken()!;
    //console.log(jwtHelper.decodeToken(token));
    return jwtHelper.decodeToken(token);
  }

  storeToken(tokenValue: string) {
    localStorage.setItem('token', tokenValue);
  }

  removeToken() {
    localStorage.removeItem('token');
  }

  getToken() {
    return localStorage.getItem('token');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }
}
