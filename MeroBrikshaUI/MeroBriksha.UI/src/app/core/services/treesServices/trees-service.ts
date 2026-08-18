import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Tree } from '../../models/trees/tree';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TreesService {

  private readonly apiUrl = 'https://merobriksha.onrender.com/api/Tree';
 
   constructor(private http: HttpClient) { }
 
   getTrees(): Observable<Tree[]> {
     return this.http.get<Tree[]>(this.apiUrl);
   }
 

}
