import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LandService {

  constructor(private httpClient: HttpClient) { }
}
