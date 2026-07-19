import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { TableColumn } from './models/table-column.model';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';


@Component({
  selector: 'app-table-widget',
  imports: [MatTableModule, MatPaginatorModule],
  templateUrl: './table-widget.html',
  styleUrl: './table-widget.css',
})
export class TableWidget {
  @Input() columns: TableColumn[] = [];
  @Input() source: any[] = [];
  dataSource: MatTableDataSource<any> = new MatTableDataSource<any>(this.source);
  pageSizeOptions: number[] = [1, 5, 10, 20];
  @ViewChild(MatPaginator) paginator!: MatPaginator; //Means : Find the MatPaginator component inside this component's template and give me a reference to it.

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  ngOnChanges(changes: SimpleChanges): void {

    if (changes['source']) {
      this.dataSource.data = this.source;
    }
  }

  get displayedColumns(): string[] { //The get keyword defines a getter.It allows you to define a method that is accessed like a property.
    return this.columns.map(column => column.key); //iterates over every item in an array and creates a new array.
  }
}
