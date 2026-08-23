import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Campaign } from '../../models/campaigns/campaign';
import { CampaignRequest } from '../../models/campaigns/campaignrequest';
import { APP_CONSTANTS } from '../../../constants/app.constant';

@Injectable({
  providedIn: 'root'
})
export class CampaignService {
  

  constructor(private http: HttpClient) { }

  getCampaigns(): Observable<Campaign[]> {
    return this.http.get<Campaign[]>(APP_CONSTANTS.API_BASE_URL + '/campaign/all');
  }

  postCampaign(campaign: CampaignRequest): Observable<Campaign> {
    return this.http.post<Campaign>(APP_CONSTANTS.API_BASE_URL + '/campaign/create', campaign);
  }

  deleteCampaign(id : string) : Observable<boolean>{
    return this.http.delete<boolean>(APP_CONSTANTS.API_BASE_URL + '/campaign/Delete/' + id);
  }
}
