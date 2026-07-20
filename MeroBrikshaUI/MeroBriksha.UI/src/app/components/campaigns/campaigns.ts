import { Component } from '@angular/core';
import { CampaignTable } from '../../widgets/campaign-table/campaign-table'; 
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';


@Component({
  selector: 'app-campaigns',
  imports: [CampaignTable, MatIconModule, MatButtonModule, Dialog, MatFormFieldModule, FormsModule],
  templateUrl: './campaigns.html',
  styleUrl: './campaigns.css',
})
export class Campaigns {
  onNewCampaignClick() {
    this.newCampaign();
  }

  newCampaign() {
    console.log('New Campaign button clicked');
  }
}
