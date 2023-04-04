import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Image } from '../models/image';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ImageService {
  // apiUrl: string = 'https://localhost:7147/api/images';
  apiUrl: string = 'https://estatewebmanagerapi20230404103531.azurewebsites.net/api/images';

  constructor(private httpClient: HttpClient) { }

  post(image: File, realEstateId: number): Observable<any> {
    console.log(`Image service call: post(${this.apiUrl}) with body: ${image}`);
    return this.httpClient.post<any>(this.apiUrl, image, { params: { "realEstateId": realEstateId } });
  }

}
