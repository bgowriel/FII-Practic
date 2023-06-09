import { Injectable } from '@angular/core';

const TOKEN_KEY = 'auth-token';
const USER_KEY = 'auth-user';

@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {
  private userEmail!: string;
  public isAdmin: boolean = false;

  constructor() { }

  signOut(): void {
    window.sessionStorage.clear();
  }

  public saveToken(token: string): void {
    window.sessionStorage.removeItem(TOKEN_KEY);
    window.sessionStorage.setItem(TOKEN_KEY, token);
  }

  public getToken(): string | null {
    return window.sessionStorage.getItem(TOKEN_KEY);
  }

  public saveUser(user: any): void {
    window.sessionStorage.removeItem(USER_KEY);
    window.sessionStorage.setItem(USER_KEY, JSON.stringify(user));
  }

  public setAdminRole(value: boolean): void {
      this.isAdmin = value;
  }

  public getUser(): any {
    const user = window.sessionStorage.getItem(USER_KEY);
    
    if (user) {
      return JSON.parse(user);
    }

    return {};
  }

  public isLoggedIn(): boolean {
    const user = window.sessionStorage.getItem(TOKEN_KEY);
    if (user) {
      return true;
    }
    return false;
  }

  public setUserEmail(value: string): void {
    this.userEmail = value;
  }

  public getUserEmail(): string {
    return this.userEmail;
  }
}
