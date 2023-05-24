import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {Record} from "../tables";

export interface DialogData {
  action: 'Insert' | 'Update' | 'Delete';
  record: Record;
}

@Component({
  selector: 'app-edit-dialog',
  templateUrl: './edit-dialog.component.html'
})
export class EditDialogComponent {
  protected data: DialogData;

  constructor(@Inject(MAT_DIALOG_DATA) private sourceData: DialogData) {
    this.data = {
      action: sourceData.action,
      record: {
        keys: sourceData.record.keys,
        values: [...sourceData.record.values]
      }
    }
  }
}
