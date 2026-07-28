import { Component, inject, model, signal } from '@angular/core';
import { CampaignTable } from '../../widgets/campaign-table/campaign-table'; 
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import {
  MAT_DIALOG_DATA,
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { DialogOverviewExample } from '../../shared/components/dialog/dialog';
import { CampaignService } from '../../core/services/campaign-service';

@Component({
  selector: 'app-campaigns',
  imports: [CampaignTable, MatIconModule, MatButtonModule],
  templateUrl: './campaigns.html',
  styleUrl: './campaigns.css',
})
export class Campaigns {

  constructor(private campaignService: CampaignService) {
  }
  onNewCampaignClick() {
    this.openDialog();
   // this.newCampaign();
  }

  newCampaign() {
    console.log('New Campaign button clicked');
    this.campaignService.postCampaign({
      name: 'Summer Donation Drive',
      description: 'A campaign to raise funds for underprivileged children.',
      organizerName: 'Everest Foundation',
      startDateUtc: '2026-08-01T00:00:00Z',
      endDateUtc: '2026-08-31T23:59:59Z'
    }).subscribe({
      next: (response) => {
        console.log('Campaign created', response);
      },
      error: (err) => {
        console.error('Error creating campaign', err);
      }
    });
  }

  readonly animal = signal('');
  readonly name = model('');
  readonly dialog = inject(MatDialog);

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogOverviewExample, {
      data: { name: this.name(), animal: this.animal() },
    });
    

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if (result !== undefined) {
        this.animal.set(result);
      }

      this.campaignService.postCampaign(result).subscribe({
        next: response => {
          console.log('Campaign created', response);
        },
        error: err => {
          console.error(err);
        }
      });
    });
  }
}
