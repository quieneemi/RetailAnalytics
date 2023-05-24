import {Component} from '@angular/core';
import {tables} from "../tables";

@Component({
  selector: 'app-table-list',
  templateUrl: './table-list.component.html'
})
export class TableListComponent {
  protected readonly tables: string[] = tables;
}
