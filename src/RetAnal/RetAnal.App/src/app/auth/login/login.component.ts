import {Component} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AuthService, LoginResponse} from "../auth.service";
import {Router} from "@angular/router";
import {NotificationsService} from "../../notifications.service";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-auth',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  protected authForm: FormGroup = this.formBuilder.group({
    username: ['', Validators.required],
    password: ['', Validators.required]
  });

  protected hide: boolean = true;

  constructor(private formBuilder: FormBuilder,
              private authService: AuthService,
              private notificationsService: NotificationsService,
              private snackBar: MatSnackBar,
              private router: Router) {
    if (authService.isAuthenticated) {
      this.router.navigate(['']);
    }
  }

  protected onSubmit(): void {
    if (this.authForm.invalid) return;

    this.authService.login(this.authForm.value.username!, this.authForm.value.password!)
      .subscribe({
        next: (response: LoginResponse) => {
          this.authService.setToken(response.token);
          this.router.navigate(['']);
        },
        error: _ => this.notificationsService.showError(this.snackBar)
      });
  }
}
