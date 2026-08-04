import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Donor } from '../../models/donors/donor';

@Injectable({
  providedIn: 'root',
})
export class DonorsService {

  private readonly apiUrl = 'https://localhost:7067/api/public/donors/getdonors';
 
   constructor(private http: HttpClient) { }
 
   getDonors(): Observable<Donor[]> {
     return this.http.get<Donor[]>(this.apiUrl);
   }
 

  
}
