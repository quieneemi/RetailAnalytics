import {Injectable} from '@angular/core';
import {MatSnackBar} from "@angular/material/snack-bar";

@Injectable({
  providedIn: 'root'
})
export class NotificationsService {
  public showError(snackBar: MatSnackBar) {
    const message: string = 'Something went wrong. Check input and try again';

    snackBar.open(message, 'Close', {
      horizontalPosition: 'end',
      verticalPosition: 'bottom',
      duration: 10000
    });
  }
}
