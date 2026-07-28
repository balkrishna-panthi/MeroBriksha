import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { TableAction, TableColumn } from './models/table-column.model';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { ColumnType, ActionType } from './models/table-column.model';
import { RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';


@Component({
  selector: 'app-table-widget',
  imports: [MatTableModule, MatPaginatorModule, RouterLink, MatButtonModule],
  templateUrl: './table-widget.html',
  styleUrl: './table-widget.css',
})
export class TableWidget {
  constructor() { }
  // Do not initialise inputs with empty arrays to avoid a change
  // from [] -> [...] during the same change detection cycle which
  // can trigger ExpressionChangedAfterItHasBeenCheckedError.
  @Input() columns?: TableColumn[];
  @Input() source?: any[];
  displayedColumns: string[] = [];

  columnType = ColumnType; //This is a property that holds the ColumnType enum. It allows you to use the enum in the template.
  actionType = ActionType; //This is a property that holds the ActionType enum. It allows you to use the enum in the template.
  dataSource: MatTableDataSource<any> = new MatTableDataSource<any>();


  pageSizeOptions: number[] = [10, 20, 30, 40, 50];
  @ViewChild(MatPaginator) paginator!: MatPaginator; //Means : Find the MatPaginator component inside this component's template and give me a reference to it.

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  ngOnChanges(changes: SimpleChanges): void {

    if (changes['source']) {
      this.dataSource.data = changes['source'].currentValue;
    }
    if (changes['columns']) {
      this.displayedColumns =
        changes['columns'].currentValue.map(
          (column: TableColumn) => column.key
        );
    }
  } 
  // get displayedColumns(): string[] { //The get keyword defines a getter.It allows you to define a method that is accessed like a property.
  //   return this.columns.map(column => column.key); //iterates over every item in an array and creates a new array.
  // }
}
