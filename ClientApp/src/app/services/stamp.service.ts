import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StampService {

  constructor(private httpClient: HttpClient) { }

  getContinents() {
    return this.httpClient.get('/api/continents');
  }

  getCategories() {
    return this.httpClient.get('/api/categories');
  }
}
