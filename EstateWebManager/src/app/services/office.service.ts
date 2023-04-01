import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Office } from '../models/office';
import { Observable } from 'rxjs';
import { PagedResponse } from '../models/paged-response';
import { OfficePut } from '../models/office-put';

@Injectable({
  providedIn: 'root'
})
export class OfficeService {
  apiUrl: string = 'https://localhost:7147/api/offices';

  constructor(private httpClient: HttpClient) { }

  get(id: number): Observable<Office> {
    return this.httpClient.get<Office>(`${this.apiUrl}/${id}`);
  }

  getByUserId(userId: string, pageNumber: number = 1, pageSize: number = 10): Observable<PagedResponse<Office[]>> {
    const queryParams = { "pageNumber": pageNumber, "pageSize": pageSize };
    
    console.log(`Office service call: getByUserId(${this.apiUrl}/user/${userId}?pageNumber=${pageNumber}&pageSize=${pageSize})`);
    return this.httpClient.get<PagedResponse<Office[]>>(`${this.apiUrl}/user/${userId}`, { params: queryParams });
  }

  getByAddress(street: string, city: string, country: string, pageNumber: number = 1, pageSize: number = 10): Observable<PagedResponse<Office[]>> {
    const queryParams = { "street": street, "city": city, "country": country, "pageNumber": pageNumber, "pageSize": pageSize };

    console.log(`Office service call: getByAddress(${this.apiUrl}/address?street=${street}&city=${city}&country=${country}&pageNumber=${pageNumber}&pageSize=${pageSize})`);
    return this.httpClient.get<PagedResponse<Office[]>>(`${this.apiUrl}/address`, { params: queryParams });
  }

  getByMinBuiltUpArea(city: string, minBuiltUpArea: number): Observable<Office[]> {
    const queryParams = { "city": city, "minBuiltUpArea": minBuiltUpArea };
    return this.httpClient.get<Office[]>(`${this.apiUrl}/built-up-area`, { params: queryParams });
  }

  getByPriceRange(city: string, min: number, max: number, currency: string, pageNumber: number = 1, pageSize: number = 10): Observable<PagedResponse<Office[]>> {
    const queryParams = { "city": city, "min": min, "max": max, "currency": currency, "pageNumber": pageNumber, "pageSize": pageSize };

    console.log(`Office service call: getByPriceRange(${this.apiUrl}/address?city=${city}&min=${min}&max=${max}&pageNumber=${pageNumber}&pageSize=${pageSize})`);
    return this.httpClient.get<PagedResponse<Office[]>>(`${this.apiUrl}/price-range`, { params: queryParams });
  }

  getByRating(city: string, rating: string): Observable<Office[]> {
    const queryParams = { "city": city, "rating": rating };
    return this.httpClient.get<Office[]>(`${this.apiUrl}/rating`, { params: queryParams });
  }

  getWithOptions(city: string, rating: string, minBuiltUpArea: number, ac: boolean, internet: boolean, parkingPlace: boolean, pageNumber: number = 1, pageSize: number = 10): Observable<PagedResponse<Office[]>> {
    const queryParams = { "city": city, "rating": rating, "minBuiltUpArea": minBuiltUpArea, "ac": ac, "internet": internet, "parkingPlace": parkingPlace, "pageNumber": pageNumber, "pageSize": pageSize };
    return this.httpClient.get<PagedResponse<Office[]>>(`${this.apiUrl}/options`, { params: queryParams });
  }

  post(office: OfficePut): Observable<Office> {
    console.log(`Office service call: post(${this.apiUrl}) with body: ${JSON.stringify(office)}`);
    return this.httpClient.post<Office>(this.apiUrl, office);
  }

  update(office: Office): Observable<Office> {
    return this.httpClient.put<Office>(`${this.apiUrl}/${office.id}`, office);
  }

  delete(id: number): Observable<{}> {
    return this.httpClient.delete(`${this.apiUrl}/${id}`);
  }

}
