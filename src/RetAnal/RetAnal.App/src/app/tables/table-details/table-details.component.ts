import {Component, OnInit} from "@angular/core";
import {ActivatedRoute} from "@angular/router";
import {TablesService} from "../tables.service";
import {Table} from "../tables";
import {PageEvent} from "@angular/material/paginator";
import {MatDialog, MatDialogRef} from "@angular/material/dialog";
import {EditDialogComponent} from "../edit-dialog/edit-dialog.component";
import {AuthService} from "../../auth/auth.service";
import {exportToCsv} from "../tables.export";
import {MatSnackBar} from "@angular/material/snack-bar";
import {NotificationsService} from "../../notifications.service";

@Component({
  selector: 'app-table-details',
  templateUrl: './table-details.component.html'
})
export class TableDetailsComponent implements OnInit {
  private tableName: string = '';
  private minDialogWidth: number = 500;

  protected table: Table | undefined;
  protected pageIndex: number = 0;
  protected pageSize: number = 10;
  protected showActions: boolean;

  constructor(private route: ActivatedRoute,
              private tablesService: TablesService,
              private dialog: MatDialog,
              private authService: AuthService,
              private snackBar: MatSnackBar,
              private notificationsService: NotificationsService) {
    this.showActions = authService.isAdministrator;
  }

  public ngOnInit(): void {
    this.tableName = this.route.snapshot.paramMap.get('tableName')!;
    this.loadTableData();
  }

  protected handlePageEvent(e: PageEvent): void {
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;
    this.loadTableData();
  }

  protected openInsertDialog(): void {
    const editDialog: MatDialogRef<any> = this.dialog.open(EditDialogComponent, {
      data: {
        action: 'Insert',
        record: {
          keys: this.table!.columns,
          values: []
        }
      },
      minWidth: this.minDialogWidth
    });
    editDialog.afterClosed().subscribe((values?: string[]) => {
      if (!values) return;

      this.tablesService.insert(this.tableName, values)
        .subscribe({
          next: _ => this.loadTableData(),
          error: _ => this.notificationsService.showError(this.snackBar)
        });
    });
  }

  protected openUpdateDialog(row: string[]): void {
    const editDialog: MatDialogRef<any> = this.dialog.open(EditDialogComponent, {
      data: {
        action: 'Update',
        record: {
          keys: this.table!.columns,
          values: row
        }
      },
      minWidth: this.minDialogWidth
    });
    editDialog.afterClosed().subscribe((values?: string[]) => {
      if (!values) return;

      this.tablesService.update(this.tableName, values)
        .subscribe({
          next: _ => this.loadTableData(),
          error: _ => this.notificationsService.showError(this.snackBar)
        });
    });
  }

  protected openDeleteDialog(row: string[]): void {
    const editDialog: MatDialogRef<any> = this.dialog.open(EditDialogComponent, {
      data: {
        action: 'Delete',
        record: {
          keys: this.table!.columns,
          values: row
        }
      },
      minWidth: this.minDialogWidth
    });
    editDialog.afterClosed().subscribe((values?: string[]) => {
      if (!values) return;

      this.tablesService.delete(this.tableName, values)
        .subscribe({
          next: _ => this.loadTableData(),
          error: _ => this.notificationsService.showError(this.snackBar)
        });
    });
  }

  protected import(event: any): void {
    const file = event.target.files[0];
    const formData: FormData = new FormData();
    formData.append('file', file);

    this.tablesService.import(this.tableName, formData)
      .subscribe({
        next: _ => this.loadTableData(),
        error: _ => this.notificationsService.showError(this.snackBar)
      });
  }

  protected export(): void {
    this.tablesService.get(this.tableName)
      .subscribe({
        next: (table: Table) => exportToCsv(table, this.tableName),
        error: _ => this.notificationsService.showError(this.snackBar)
      });
  }

  private loadTableData(): void {
    this.tablesService.get(this.tableName, this.pageIndex,  this.pageSize)
      .subscribe({
        next: (table: Table) => this.table = table,
        error: _ => this.notificationsService.showError(this.snackBar)
      });
  }
}
