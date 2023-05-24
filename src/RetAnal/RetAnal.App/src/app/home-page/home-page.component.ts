import {Component} from '@angular/core';
import {AuthService} from "../auth/auth.service";

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html'
})
export class HomePageComponent {
  constructor(protected authService: AuthService) {}
}
