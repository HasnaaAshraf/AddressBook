import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm: FormGroup;
  errorMessage: string = '';

  
  constructor( private fb: FormBuilder, private http: HttpClient, private router: Router) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.loginForm.invalid) {
      this.errorMessage = 'Please enter username and password';
      return;
    }

    const loginData = this.loginForm.value;

    this.http.post<any>('https://localhost:7215/api/User/login', loginData)
      .subscribe({
        next: (res) => {
          if (res) {
            localStorage.setItem('currentUserId', res.id);
            this.router.navigate(['/addressbook']);
            this.errorMessage = '';
          } else {
            this.errorMessage = 'Invalid username or password';
          }
        },
        error: (err) => {
          console.error(err);
          this.errorMessage = 'Server error. Please try again later.';
        }
      });
  }
}