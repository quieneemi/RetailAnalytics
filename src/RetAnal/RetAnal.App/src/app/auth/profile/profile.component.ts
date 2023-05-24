import {Component} from '@angular/core';
import {AuthService} from "../auth.service";

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html'
})
export class ProfileComponent {
  constructor(protected authService: AuthService) {}
}
