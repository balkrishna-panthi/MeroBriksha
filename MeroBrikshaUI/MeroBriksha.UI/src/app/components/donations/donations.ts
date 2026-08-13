import { Component, EventEmitter } from '@angular/core';
import { DoantionService } from '../../core/services/donationServices/doantion-service';
import { Observable } from 'rxjs';
import { Donation } from '../../core/models/donations/donation';
import { DonationsTable } from '../../widgets/donations-table/donations-table';

@Component({
  selector: 'app-donations',
  imports: [DonationsTable],
  templateUrl: './donations.html',
  styleUrl: './donations.css',
})
  export class Donations {

    constructor(private donationService: DoantionService) {

    }
    ngOnInit() {}
  }
