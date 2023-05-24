import {inject} from '@angular/core';
import {Router, UrlTree} from '@angular/router';
import {AuthService} from "./auth.service";

export const authGuard = (): boolean | UrlTree => {
  const router: Router = inject(Router);
  const authService: AuthService = inject(AuthService);

  if (authService.isAuthenticated) {
    return true;
  }

  return router.parseUrl('/login');
};

export const adminGuard = (): boolean | UrlTree => {
  const router: Router = inject(Router);
  const authService: AuthService = inject(AuthService);

  if (authService.isAuthenticated && authService.isAdministrator) {
    return true;
  }

  return router.parseUrl('');
};
