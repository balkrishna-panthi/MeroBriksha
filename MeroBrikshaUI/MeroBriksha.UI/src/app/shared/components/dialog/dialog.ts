import { Component, inject, model, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
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
import { CampaignService } from '../../../core/services/campaignServices/campaign-service';

export interface DialogData {
  animal: string;
  name: string;
  campaignName: string;
  campaignDescription: string;
  organizerName: string;
  startDate: string;
  endDate: string;
}

/**
 * @title Dialog Overview
 */
@Component({
  selector: 'app-dialog',
  templateUrl: 'dialog.html',
  imports: [MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule],
})
export class Dialog {
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

@Component({
  selector: 'dialog-overview-example',
  templateUrl: 'dialog-overview-example.html',
  imports: [
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
  ],
})
export class DialogOverviewExample {

  constructor(private campaignService : CampaignService) {
  }
  readonly dialogRef = inject(MatDialogRef<DialogOverviewExample>);
  readonly data = inject<DialogData>(MAT_DIALOG_DATA);
  readonly animal = model(this.data.animal);
  readonly campaignName = model(this.data.campaignName);
  readonly campaignDescription = model(this.data.campaignDescription);
  readonly organizerName = model(this.data.organizerName);
  readonly startDate = model(this.data.startDate);
  readonly endDate = model(this.data.endDate);

  submit(): void {

    this.dialogRef.close({
      name: this.campaignName(),
      description: this.campaignDescription(),
      organizerName: this.organizerName(),
      startDateUtc: new Date(this.startDate()).toISOString(),
      endDateUtc: new Date(this.endDate()).toISOString()
    });   
  }
  onNoClick(): void {
    this.dialogRef.close();
    // this.dialogRef.afterClosed().subscribe(() => {
    //   console.log('Dialog closed with animal:', this.animal());
    // });
  }
}
