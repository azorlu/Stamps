import { SaveStamp } from './../models/saveStamp';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StampService {

  private readonly stampsEndpoint = '/api/stamps';
  
  constructor(private httpClient: HttpClient) { }

  getContinents() {
    return this.httpClient.get('/api/continents');
  }

  getCountries() {
    return this.httpClient.get('/api/countries');
  }

  getCategories() {
    return this.httpClient.get('/api/categories');
  }

  create(stamp) {
    return this.httpClient.post(this.stampsEndpoint, stamp);
  }

  load(id) {
    return this.httpClient.get(this.stampsEndpoint + '/' + id);
  }

  loadAll(filter){
    return this.httpClient.get(this.stampsEndpoint  + '?' + this.toQueryString(filter));
  }

  toQueryString(obj) {
    var parts = [];
    for (var property in obj) {
      var value = obj[property];
      if (value != null && value != undefined) 
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
    }

    return parts.join('&');
  }

  update(stamp: SaveStamp) {
    return this.httpClient.put(this.stampsEndpoint + '/' + stamp.id, stamp);
  }

  delete(id) {
    return this.httpClient.delete(this.stampsEndpoint + '/' + id);
  }
}
