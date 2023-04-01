import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable, Subject } from 'rxjs';
import { Area } from '../models/area';

@Injectable({
  providedIn: 'root',
})
export class AreaService implements OnInit {
  apiUrl = 'https://localhost:7147/api/areas';

  constructor(private httpClient: HttpClient) {}

  ngOnInit(): void {
  }

  get(id: number): Observable<Area> {
    return this.httpClient.get<Area>(`${this.apiUrl}/${id}`);
  }

  getAreas(): Observable<Area[]> {
    return this.httpClient.get<Area[]>(this.apiUrl);
  }

  getByCity(city: string): Observable<Area[]> {
    return this.httpClient.get<Area[]>(`${this.apiUrl}/city/${city}`);
  }

  getByCountry(country: string): Observable<Area[]> {
    return this.httpClient.get<Area[]>(`${this.apiUrl}/country/${country}`);
  }

  post(area: Area): Observable<Area> {
    return this.httpClient.post<Area>(this.apiUrl, area);
  }

  update(area: Area): Observable<Area> {
    return this.httpClient.put<Area>(`${this.apiUrl}/${area.id}`, area);
  }

  delete(id: number): Observable<{}> {
    return this.httpClient.delete(`${this.apiUrl}/${id}`);
  }

}
