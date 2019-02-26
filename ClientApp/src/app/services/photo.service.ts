import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {

  constructor(private httpClient: HttpClient) {

  }

  upload(stampId, photoFile) {
    var formData = new FormData();
    formData.append('file', photoFile);

    return this.httpClient.post(`/api/stamps/${stampId}/photos`, formData);
  }

  loadByStampId(stampId) {
    return this.httpClient.get(`/api/stamps/${stampId}/photos`);
  }
  
}
