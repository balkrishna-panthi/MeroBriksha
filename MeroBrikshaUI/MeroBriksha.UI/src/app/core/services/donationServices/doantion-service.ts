import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Donation } from '../../models/donations/donation';
import { Observable } from 'rxjs';
import { Donor } from '../../models/donors/donor';

@Injectable({
  providedIn: 'root',
})
export class DoantionService {

  private readonly apiUrl = 'https://merobriksha.onrender.com/api/Donations/GetAll';
   
     constructor(private http: HttpClient) { }
   
     getDonors(): Observable<Donation[]> {
       return this.http.get<Donation[]>(this.apiUrl);
     }
     totalDonationPerCampaign(campaignId : string) : Observable<any>{
      return this.http.get<number>("https://merobriksha.onrender.com/api/Donations/TotalByCampaignID/"+campaignId);

     }
   
  
}
