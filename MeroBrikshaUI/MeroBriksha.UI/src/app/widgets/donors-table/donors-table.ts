import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ActionType, ColumnType, TableColumn } from '../table-widget/models/table-column.model';
import { TableWidget } from "../table-widget/table-widget";
import { Donor } from '../../core/models/donors/donor';
import { Observable } from 'rxjs/internal/Observable';
import { AsyncPipe } from '@angular/common';
import { DonorsService } from '../../core/services/donorsServices/donors-service';

@Component({
  selector: 'app-donors-table',
  imports: [TableWidget, AsyncPipe],
  templateUrl: './donors-table.html',
  styleUrl: './donors-table.css',
})
export class DonorsTable {
  donors$?: Observable<Donor[]>;

  columns: TableColumn[] = [
    {
      key: 'id',
      label: 'ID',
      type: ColumnType.text
    },
    {
      key: 'fullname',
      label: 'FullName',
      type: ColumnType.text
    },
    {
      key: 'email',
      label: 'Email',
      type: ColumnType.text
    },
    {
      key: 'address',
      label: 'Address',
      type: ColumnType.text
    },
    {
      key: 'createdDated',
      label: 'Created Date',
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
            onClick: row => this.deleteDonors(row.id)
          }
        ]
      }
    }
  ];

  constructor(private donorService : DonorsService){
  
  }
  ngOnInit(){
    this.getDonors();
  }
  
  getDonors(){
    this.donors$ = this.donorService.getDonors();
  }
  deleteDonors(id : string){
    console.log('delete donors clicked: ' + id);
  }
}
