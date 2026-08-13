import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Donation } from '../../core/models/donations/donation';
import { ActionType, ColumnType, TableColumn } from '../table-widget/models/table-column.model';

import { TableWidget } from '../table-widget/table-widget';
import { AsyncPipe } from '@angular/common';
import { DoantionService } from '../../core/services/donationServices/doantion-service';

@Component({
  selector: 'app-donations-table',
  imports: [TableWidget, AsyncPipe],
  templateUrl: './donations-table.html',
  styleUrl: './donations-table.css',
})
export class DonationsTable {
 donations$?: Observable<Donation[]>;


  columns: TableColumn[] = [
    {
      key: 'id',
      label: 'Donation ID',
      type: ColumnType.text
    },
    {
      key: 'campaignName',
      label: 'Campaign Name',
      type: ColumnType.text
    },
    {
      key: 'donorName',
      label: 'Donor Name',
      type: ColumnType.text
    },
    {
      key: 'status',
      label: 'Status',
      type: ColumnType.text
    },
    {
      key: 'verifiedDate',
      label: 'VerifiedDate',
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
            routerLink: row => ['/donations', row.id]
          },
          {
            label: 'Edit',
            type: ActionType.link,
            routerLink: row => ['/donations', row.id, 'edit']
          },
          {
            label: 'Delete',
            type: ActionType.button,
            onClick: row => this.deleteDonation(row.id)
          }
        ]
      }
    }
  ];



  constructor(private donationService: DoantionService) {

  }
  ngOnInit() {
    this.getDonations();
  }

  getDonations() {
    this.donations$ = this.donationService.getDonors();
  }

  deleteDonation(donationId: string) {
    console.log("donation to delete : " + donationId);
  }
}
