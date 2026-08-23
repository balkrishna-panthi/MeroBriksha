import { Component, SimpleChanges } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Donation } from '../../core/models/donations/donation';
import { DoantionService } from '../../core/services/donationServices/doantion-service';
import { JsonPipe } from '@angular/common';
import { signal } from '@angular/core';

@Component({
  selector: 'app-campaign',
  imports: [JsonPipe],
  templateUrl: './campaign.html',
  styleUrl: './campaign.css',
})
export class Campaign {
  totalDonation = signal<any>(null);
  campaignId!: string; constructor(
    private route: ActivatedRoute,
    private donationService: DoantionService
  ) {
    console.log('1 constructor');
  }

  ngOnInit() {
    console.log('2 ngOnInit');

    this.campaignId = this.route.snapshot.paramMap.get('id')!;

    this.donationService
      .totalDonationPerCampaign(this.campaignId)
      .subscribe({
        next: result => {

          console.log('HTTP response');

          this.totalDonation.set(result);

          console.log('totalDonation assigned');
        },
        error: (err) => {
          console.error('Error deleting campaign', err);
        }
      }
      );
  }

  // ngDoCheck() {
  //   console.log('3 ngDoCheck');
  // }

  // ngAfterViewInit() {
  //   console.log('4 ngAfterViewInit');
  // }

  // ngAfterViewChecked() {
  //   console.log('5 ngAfterViewChecked');
  // }

  // ngOnDestroy() {
  //   console.log('6 ngOnDestroy');
  // }
  // test(){
  //   console.log("TEST CLICKED!!")
  // }
}
