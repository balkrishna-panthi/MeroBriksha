import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Campaign } from '../models/campaign';
import { CampaignRequest } from '../models/campaignrequest';

@Injectable({
  providedIn: 'root'
})
export class CampaignService {

  private readonly apiUrl = 'https://localhost:7067/api/campaign/all';

  constructor(private http: HttpClient) { }

  getCampaigns(): Observable<Campaign[]> {
    return this.http.get<Campaign[]>(this.apiUrl);
  }

  postCampaign(campaign: CampaignRequest): Observable<Campaign> {
    return this.http.post<Campaign>('https://localhost:7067/api/campaign/create', campaign);
  }

  deleteCampaign(id : string) : Observable<boolean>{
    return this.http.delete<boolean>('https://localhost:7067/api/Campaign/Delete/'+id);
  }
}
