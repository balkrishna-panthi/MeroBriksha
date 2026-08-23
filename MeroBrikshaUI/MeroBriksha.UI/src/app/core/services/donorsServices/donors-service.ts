import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Donor } from '../../models/donors/donor';
import { APP_CONSTANTS } from '../../../constants/app.constant';

@Injectable({
  providedIn: 'root',
})
export class DonorsService {

   constructor(private http: HttpClient) { }
 
   getDonors(): Observable<Donor[]> {
     return this.http.get<Donor[]>(APP_CONSTANTS.API_BASE_URL + '/public/donors/getdonors');
   }
 

  
}
