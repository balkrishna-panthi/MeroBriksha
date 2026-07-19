import { Component } from '@angular/core';
import { CampaignTable } from '../../widgets/campaign-table/campaign-table'; 

@Component({
  selector: 'app-campaigns',
  imports: [CampaignTable],
  templateUrl: './campaigns.html',
  styleUrl: './campaigns.css',
})
export class Campaigns {}
