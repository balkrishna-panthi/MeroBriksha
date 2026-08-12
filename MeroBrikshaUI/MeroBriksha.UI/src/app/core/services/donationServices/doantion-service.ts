import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Donation } from '../../models/donations/donation';
import { Observable } from 'rxjs';
import { Donor } from '../../models/donors/donor';

@Injectable({
  providedIn: 'root',
})
export class DoantionService {

   private readonly apiUrl = 'https://localhost:7067/api/Donations/GetAll';
   
     constructor(private http: HttpClient) { }
   
     getDonors(): Observable<Donation[]> {
       return this.http.get<Donation[]>(this.apiUrl);
     }
   
  
}
