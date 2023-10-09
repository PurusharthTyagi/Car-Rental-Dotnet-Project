// LoginComponent (login.component.ts)
import { Component } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../Services/user.service';
import { Login } from '../models/models';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  hide = true;
  loginForm: FormGroup;
  responseMsg: string = '';
  loginInfo: Login = {
    Username: '',
    Password: '',
  };

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private userService: UserService
  ) {
    this.loginForm = fb.group({
      email: fb.control('', [Validators.required, Validators.email]),
      password: fb.control('', [
        Validators.required,
        Validators.minLength(8),
        Validators.maxLength(15),
      ]),
    });
  }

  getEmailErrors() {
    if (this.Email.hasError('required')) return 'Email is required!';
    if (this.Email.hasError('email')) return 'Email is invalid.';
    return '';
  }

  getPasswordErrors() {
    if (this.Password.hasError('required')) return 'Password is required!';
    if (this.Password.hasError('minlength'))
      return 'Minimum 8 characters are required!';
    if (this.Password.hasError('maxlength'))
      return 'Maximum 15 characters are required!';
    return '';
  }

  get Email(): FormControl {
    return this.loginForm.get('email') as FormControl;
  }
  get Password(): FormControl {
    return this.loginForm.get('password') as FormControl;
  }

  login() {
    this.loginInfo = {
      Username: this.loginForm.get('email')?.value,
      Password: this.loginForm.get('password')?.value,
    };

    this.userService.login(this.loginInfo).subscribe({
      next: (response) => {
        if (response == 'Failure') {
          alert('Wrong Credentials !');
          this.loginForm.reset();
        } else {
          this.userService.storeToken(response);
          const payload = this.userService.decodedToken();
          console.log(payload);
          this.router.navigateByUrl('/cars/warehouse');
        }
      },
      error: (err) => {
        console.log('error', err);
      },
    });
  }
}
