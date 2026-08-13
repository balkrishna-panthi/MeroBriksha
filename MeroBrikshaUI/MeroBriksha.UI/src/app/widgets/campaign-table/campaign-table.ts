import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { MatTableModule } from '@angular/material/table';
import { TableWidget } from '../table-widget/table-widget';
import { ActionType, ColumnType, TableColumn } from '../table-widget/models/table-column.model';
import { CampaignService } from '../../core/services/campaignServices/campaign-service';
import { Campaign } from '../../core/models/campaigns/campaign';
import { AsyncPipe, CommonModule } from '@angular/common';

@Component({
  selector: 'app-campaign-table',
  imports: [MatTableModule, TableWidget, AsyncPipe, CommonModule],
  templateUrl: './campaign-table.html',
  styleUrl: './campaign-table.css',
})
export class CampaignTable {
  campaigns$?: Observable<Campaign[]>;

  columns: TableColumn[] = [
    {
      key: 'id',
      label: 'Campaign ID',
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
      key: 'organizerName',
      label: 'Organizer Name',
      type: ColumnType.text
    },
    {
      key: 'startDateUtc',
      label: 'Start Date',
      type: ColumnType.text
    },
    {
      key: 'endDateUtc',
      label: 'End Date',
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
            routerLink: row => ['/campaigns', row.id]
          },
          {
            label: 'Edit',
            type: ActionType.link,
            routerLink: row => ['/campaigns', row.id, 'edit']
          },
          {
            label: 'Delete',
            type: ActionType.button,
            onClick: row => this.deleteCampaign(row.id)
          }
        ]
      }
    }
  ];
  
  ngOnInit(){
    this.getCampaigns();
  }
  constructor(private campaignService: CampaignService) {
  }


  deleteCampaign(campaignId: string): void {
    this.campaignService.deleteCampaign(campaignId).subscribe(
      {
        next: result => {
          console.log("The deletion result is : " + result);
        },
        error: (err) => {
          console.error('Error deleting campaign', err);
        }
      }
    );

  }

  getCampaigns() {
    this.campaigns$ = this.campaignService.getCampaigns();
  }
}
