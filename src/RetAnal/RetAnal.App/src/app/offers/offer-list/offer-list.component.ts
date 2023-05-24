import {Component} from '@angular/core';
import {Offer, offers} from "../offers";
import {MatDialog} from "@angular/material/dialog";
import {OfferResultComponent} from "../offer-result/offer-result.component";
import {Table} from "../../tables/tables";
import {OffersService} from "../offers.service";
import {MatSnackBar} from "@angular/material/snack-bar";
import {NotificationsService} from "../../notifications.service";

@Component({
  selector: 'app-offer-list',
  templateUrl: './offer-list.component.html'
})
export class OfferListComponent {
  protected readonly offers: Offer[] = offers;
  protected processing: boolean = false;

  constructor(private offersService: OffersService,
              private dialog: MatDialog,
              private snackBar: MatSnackBar,
              private notificationsService: NotificationsService) {}

  protected executeOffer(offer: Offer) {
    this.processing = true;

    const values: string[] = [];
    for (let i = 0; i < offer.parameters.length; i++) {
      values.push(offer.parameters[i].value.toString());
    }

    this.offersService
      .execute(offer.title, values)
      .subscribe({
        next: (result: Table) => {
          this.processing = false;
          this.showResult(result);
        },
        error: _ => {
          this.processing = false;
          this.notificationsService.showError(this.snackBar);
        }
      });
  }

  private showResult(result: Table): void {
    this.dialog.open(OfferResultComponent, {
      data: {
        table: result
      }
    });
  }
}
