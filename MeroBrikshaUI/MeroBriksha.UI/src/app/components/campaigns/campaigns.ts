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

@Component({
  selector: 'app-campaigns',
  imports: [CampaignTable, MatIconModule, MatButtonModule],
  templateUrl: './campaigns.html',
  styleUrl: './campaigns.css',
})
export class Campaigns {
  onNewCampaignClick() {
    this.openDialog();
  }

  newCampaign() {
    console.log('New Campaign button clicked');
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
    });
  }
}
