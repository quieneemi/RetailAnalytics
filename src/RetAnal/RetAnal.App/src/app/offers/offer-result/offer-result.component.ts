import {Component, Inject} from '@angular/core';
import {Table} from "../../tables/tables";
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {exportToCsv} from "../../tables/tables.export";

export interface ResultData {
  table: Table;
}

@Component({
  selector: 'app-offer-result',
  templateUrl: './offer-result.component.html'
})
export class OfferResultComponent {
  protected data: ResultData;

  constructor(@Inject(MAT_DIALOG_DATA) private resultData: ResultData) {
    this.data = {
      table: {...resultData.table}
    }
  }

  protected export(): void {
    exportToCsv(this.data.table, Date.now().toString());
  }
}
