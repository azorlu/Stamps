import { SaveStamp } from './../models/saveStamp';
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

  create(stamp) {
    return this.httpClient.post('/api/stamps', stamp);
  }

  load(id) {
    return this.httpClient.get('/api/stamps/' + id);
  }

  update(stamp: SaveStamp) {
    return this.httpClient.put('/api/stamps/' + stamp.id, stamp);
  }

  delete(id) {
    return this.httpClient.delete('api/stamps/' + id);
  }
}
