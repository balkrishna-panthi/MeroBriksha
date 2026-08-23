import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Tree } from '../../models/trees/tree';
import { Observable } from 'rxjs';
import { APP_CONSTANTS } from '../../../constants/app.constant';

@Injectable({
  providedIn: 'root',
})
export class TreesService {

   constructor(private http: HttpClient) { }
 
   getTrees(): Observable<Tree[]> {
     return this.http.get<Tree[]>(APP_CONSTANTS.API_BASE_URL + '/Tree');
   }
 

}
