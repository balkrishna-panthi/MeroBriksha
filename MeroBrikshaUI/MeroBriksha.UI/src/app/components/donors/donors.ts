import { Component } from '@angular/core';
import { DonorsService } from '../../core/services/donorsServices/donors-service';
import { DonorsTable } from "../../widgets/donors-table/donors-table";
import { Observable } from 'rxjs';
import { Donor } from '../../core/models/donors/donor';

@Component({
  selector: 'app-donors',
  imports: [DonorsTable],
  templateUrl: './donors.html',
  styleUrl: './donors.css',
})
export class Donors {
  donorsList$? : Observable<Donor[]>;

constructor(private donorService : DonorsService){

}
ngOnInit(){
  this.getDonors();
}

getDonors(){
  this.donorsList$ = this.donorService.getDonors();
}
}
