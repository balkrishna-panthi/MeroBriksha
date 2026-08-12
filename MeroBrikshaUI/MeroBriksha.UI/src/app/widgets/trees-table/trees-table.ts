import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Tree } from '../../core/models/trees/tree';
import { ActionType, ColumnType, TableColumn } from '../table-widget/models/table-column.model';
import { TableWidget } from '../table-widget/table-widget';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-trees-table',
  imports: [TableWidget, AsyncPipe],
  templateUrl: './trees-table.html',
  styleUrl: './trees-table.css',
})
export class TreesTable {
@Input() trees$? : Observable<Tree[]>;
 @Output() delete = new EventEmitter<string>();
columns: TableColumn[] = [
    {
      key: 'id',
      label: 'ID',
      type: ColumnType.text
    },
    {
      key: 'treeAssignmentId',
      label: 'Tree Assignment Id',
      type: ColumnType.text
    },
    {
      key: 'name',
      label: 'Name',
      type: ColumnType.text
    },
    {
      key: 'description',
      label: 'Description',
      type: ColumnType.text
    },
    {
      key: 'species',
      label: 'Species',
      type: ColumnType.text
    },
    {
      key: 'donorName',
      label: 'Donor Name',
      type: ColumnType.text
    },
    {
      key: 'actions',
      label: 'Actions',
      type: ColumnType.actions,
      config: {
        actions: [
          {
            label: 'View',
            type: ActionType.link,
            routerLink: row => ['/donors', row.id]
          },
          {
            label: 'Edit',
            type: ActionType.link,
            routerLink: row => ['/donors', row.id, 'edit']
          },
          {
            label: 'Delete',
            type: ActionType.button,
            onClick: row => this.deleteTree(row.id)
          }
        ]
      }
    }
  ];

  deleteTree(id : string){
      this.delete.emit(id);
  }
}
