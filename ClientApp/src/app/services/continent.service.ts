import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ContinentService {

  constructor(private httpClient: HttpClient) { }

  getContinents() {
    return this.httpClient.get('/api/continents');
  }
}
