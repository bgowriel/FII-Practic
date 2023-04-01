import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../services/authentication.service';
import { TokenStorageService } from '../services/token-storage.service';
import jwtDecode from 'jwt-decode';
import { Router } from '@angular/router';
import { User } from '../models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  isSuccessful = false;
  isSignUpFailed = false;

  isLoggedIn = false;
  isLoginFailed = false;

  errorMessage = '';
  roles: string[] = [];

  email = new FormControl('', [Validators.required, Validators.email]);
  password = new FormControl('', [
    Validators.required,
    Validators.minLength(8),
  ]);
  loginForm = new FormGroup({
    emailInput: this.email,
    passwordInput: this.password,
  });

  hide: boolean = true;

  user!: User;

  constructor(
    private authService: AuthenticationService,
    private tokenStorage: TokenStorageService,
    private router: Router
  ) {}

  ngOnInit(): void {
    if (this.authService.isAuthenticated) this.router.navigate(['/', 'offices']);
      
    if (this.tokenStorage.getToken()) {
      this.isLoggedIn = true;
      this.roles = this.tokenStorage.getUser().roles;
    }
  }

  onRegisterSubmit(): void {
    this.authService
      .register(
        this.email.value ? this.email.value : '',
        this.password.value ? this.password.value : ''
      )
      .subscribe({
        next: (data) => {
          console.log("Register response: " + data);
          this.isSuccessful = true;
          this.isSignUpFailed = false;
          this.isLoginFailed = false;
        },
        error: (err) => {
          console.log("Register error: " + err.error.message);
          if (err.error.message) {
            this.errorMessage = err.error.message;
          } else {
            this.errorMessage =
              'Register failed. User already exists!';
          }
          this.isSignUpFailed = true;
        },
      });
  }

  onLoginSubmit(): void {
    this.authService
      .login(
        this.email.value ? this.email.value : '',
        this.password.value ? this.password.value : ''
      )
      .subscribe({
        next: (data) => {
          console.log(data);
          console.log(jwtDecode(data.token));

          this.user = jwtDecode(data.token);
          this.tokenStorage.setUserEmail(this.user.email);

          if (this.user.role != undefined && this.user.role[1] == 'admin') this.tokenStorage.setAdminRole(true)
          else this.tokenStorage.setAdminRole(false);

          this.tokenStorage.saveToken(data.token);
          this.tokenStorage.saveUser(data);

          this.isLoginFailed = false;
          this.isSignUpFailed = false;
          this.isLoggedIn = true;
          this.roles = this.tokenStorage.getUser().roles;
          this.authService.setAuthentication(true);

          this.router.navigate(['/', 'offices']);
        },
        error: (err) => {
          if (err.error.message) {
            this.errorMessage = err.error.message;
          } else {
            this.errorMessage =
              'Login failed. Please check email and password!';
          }
          this.isLoginFailed = true;
        },
      });
  }

  reloadPage(): void {
    window.location.reload();
  }

  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }
}
