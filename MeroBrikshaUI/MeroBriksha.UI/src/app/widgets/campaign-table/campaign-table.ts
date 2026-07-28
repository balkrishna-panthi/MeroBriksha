import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { MatTableModule } from '@angular/material/table';
import { TableWidget } from '../table-widget/table-widget'; 
import { ActionType, ColumnType, TableColumn } from '../table-widget/models/table-column.model';
import { CampaignService } from '../../core/services/campaign-service';
import { Campaign } from '../../core/models/campaign';
import { AsyncPipe, CommonModule } from '@angular/common';
export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}
const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H' },
  { position: 2, name: 'Helium', weight: 4.0026, symbol: 'He' },
  { position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li' },
  { position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be' },
  { position: 5, name: 'Boron', weight: 10.811, symbol: 'B' },
  { position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C' },
  { position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N' },
  { position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O' },
  { position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F' },
  { position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne' },
];
@Component({
  selector: 'app-campaign-table',
  imports: [MatTableModule, TableWidget, AsyncPipe, CommonModule],
  templateUrl: './campaign-table.html',
  styleUrl: './campaign-table.css',
})
export class CampaignTable {
  @Output() delete = new EventEmitter<string>();
  //displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  

  
  columns: TableColumn[] = [
    {
      key: 'id',
      label: 'Campaign ID',
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
            onClick: row => this.deleteCampaign(row.campaignId)
          }
        ]
      }
    }
  ];

  campaigns$?: Observable<Campaign[]>;

  constructor(
    private campaignService: CampaignService
  ) { }

  ngOnInit(): void {
    // Expose the campaigns Observable and use the async pipe in the template.
    // This is the idiomatic Angular approach and avoids ExpressionChangedAfterItHasBeenCheckedError.
    this.campaigns$ = this.campaignService.getCampaigns();
  }
  
  dataSource = ELEMENT_DATA;
  dummyData  = [
    {
      campaignId: 'CMP-2026-001',
      name: 'Tamghas Green Hills 2026',
      description: 'A community-driven tree plantation campaign to restore degraded hillside areas around Tamghas.',
      organizationName: 'Tamghas Youth Club',
      startDate: '2026-06-01',
      endDate: '2026-08-31'
    },
    {
      campaignId: 'CMP-2026-002',
      name: 'Gulmi Community Forest Initiative',
      description: 'A campaign focused on increasing tree coverage through community participation and local donations.',
      organizationName: 'Gulmi Community Forest Group',
      startDate: '2026-05-15',
      endDate: '2026-10-15'
    },
    {
      campaignId: 'CMP-2026-003',
      name: 'One Donor One Tree',
      description: 'An initiative connecting individual donors with tree plantation activities across selected locations.',
      organizationName: 'MeroBriksha Foundation',
      startDate: '2026-07-01',
      endDate: '2026-12-31'
    },
    {
      campaignId: 'CMP-2026-004',
      name: 'School Green Nepal',
      description: 'A tree plantation campaign involving schools, students, teachers, and local volunteers.',
      organizationName: 'Nepal Youth Environmental Network',
      startDate: '2026-07-15',
      endDate: '2026-09-30'
    },
    {
      campaignId: 'CMP-2026-005',
      name: 'Community Forest Restoration',
      description: 'A long-term plantation campaign focused on restoring local forest areas and improving biodiversity.',
      organizationName: 'Green Nepal Initiative',
      startDate: '2026-04-01',
      endDate: '2026-11-30'
    }
  ];

  deleteCampaign(campaignId: string): void
  {
    console.log(`Delete campaign with ID: ${campaignId}`);
  }
}
