import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';  
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {  
  
  constructor(private router: Router, private authService: AuthenticationService) { }  
  
  canActivate() {  
    if (this.authService.isAuthenticated) return true;

    this.router.navigate(['/', 'login']);
    return false;
  }  
}  
