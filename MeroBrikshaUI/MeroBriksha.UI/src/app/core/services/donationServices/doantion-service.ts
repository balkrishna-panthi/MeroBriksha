import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Donation } from '../../models/donations/donation';
import { Observable } from 'rxjs';
import { Donor } from '../../models/donors/donor';
import { APP_CONSTANTS } from '../../../constants/app.constant';

@Injectable({
  providedIn: 'root',
})
export class DoantionService {

     constructor(private http: HttpClient) { }
   
     getDonors(): Observable<Donation[]> {
       return this.http.get<Donation[]>(APP_CONSTANTS.API_BASE_URL + '/Donations/GetAll');
     }
     totalDonationPerCampaign(campaignId : string) : Observable<any>{
      return this.http.get<any>(APP_CONSTANTS.API_BASE_URL + '/Donations/TotalByCampaignID/' + campaignId);
     }
   
  
}
