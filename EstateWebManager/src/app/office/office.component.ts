import { Component, OnInit, ViewChild } from '@angular/core';
import { AreaService } from '../services/area.service';
import { OfficeService } from '../services/office.service';
import { SelectPriceComponent } from '../core/select-price/select-price.component';
import { Office } from '../models/office';
import { AuthenticationService } from '../services/authentication.service';
import { PostOfferComponent } from '../core/post-offer/post-offer.component';
import { TokenStorageService } from '../services/token-storage.service';
import jwtDecode from 'jwt-decode';

@Component({
  selector: 'app-office',
  templateUrl: './office.component.html',
  styleUrls: ['./office.component.css'],
})
export class OfficeComponent implements OnInit {
  country!: string;
  city!: string;
  street!: string;

  currency!: string;
  minPrice!: number;
  maxPrice!: number;

  ac: boolean = false;
  internet: boolean = false;
  parking: boolean = false;
  rating: string = 'C';
  minArea: number = 0;

  offices!: Office[];
  searchType!: string;
  resultsCount!: number;

  details: boolean = false;
  postOffer: boolean = false;
  _showOffices: boolean = false;
  dashboard: boolean = false;
  currentOffice!: Office;

  constructor(
    private officeService: OfficeService,
    private areaService: AreaService,
    private authService: AuthenticationService,
    private tokenService: TokenStorageService
  ) {}

  ngOnInit(): void {
  }

  fetchData(actionType: string, page: number = 1, size: number = 10) {
    this.searchType = actionType;

    if (actionType == 'byAddress') {
      this.officeService
        .getByAddress(
          this.street ? this.street : '',
          this.city ? this.city : '',
          this.country,
          page,
          size
        )
        .subscribe(
          (response) => {
            this.offices = response.data;
            this.resultsCount = response.totalRecords;
            console.log(response);
          },
          (error) => console.log(error)
        );
    }

    if (actionType == 'byPrice') {
      this.officeService
        .getByPriceRange(
          this.city,
          this.minPrice,
          this.maxPrice,
          this.currency,
          page,
          size
        )
        .subscribe(
          (response) => {
            this.offices = response.data;
            this.resultsCount = response.totalRecords;
            console.log(response);
          },
          (error) => console.log(error)
        );
    }

    if (actionType == 'withOptions') {
      this.officeService
        .getWithOptions(
          this.city,
          this.rating,
          this.minArea,
          this.ac,
          this.internet,
          this.parking,
          page,
          size
        )
        .subscribe(
          (response) => {
            this.offices = response.data;
            this.resultsCount = response.totalRecords;
            console.log(response);
          },
          (error) => console.log(error)
        );
    }

    if (actionType == 'byUser') {
      let userData = this.tokenService.getUser();
      let user: any = jwtDecode(userData.token);
      this.officeService
        .getByUserId(user.userId, page, size)
        .subscribe(
          (response) => {
            this.offices = response.data;
            this.resultsCount = response.totalRecords;
            console.log(response);
          },
          (error) => console.log(error)
        );
    }
  }

  deleteEstate() {
    this.officeService.delete(this.currentOffice.id).subscribe(
      (response) => {
        console.log(response);
        this.fetchData('byUser');
      });
  }

  showPostOffer() {
    // console.log(this.postOffer);
    // this._showOffices = false;
    this.postOffer = true;
  }

  hidePostOffer() {
    this.postOffer = false;
    // this._showOffices = true;
  }

  showOffices() {
    // this.postOffer = false;
    this._showOffices = true;
  }

  hideOffices() {
    this._showOffices = false;
    this.offices = [];
  }

  setCountry(name: string) {
    this.country = name;
  }

  setCity(name: string) {
    this.city = name;
  }

  setStreet(name: string) {
    this.street = name;
  }

  pageChange(event: any) {
    this.fetchData(this.searchType, event.pageIndex + 1, event.pageSize);
    console.log(event.pageIndex + 1, event.pageSize);
  }

  setCurrency(value: string) {
    this.currency = value;
  }

  setMinPrice(value: number) {
    this.minPrice = value;
  }

  setMaxPrice(value: number) {
    this.maxPrice = value;
  }

  setAc(value: boolean) {
    this.ac = value;
  }

  setInternet(value: boolean) {
    this.internet = value;
  }
  
  setRating(value: string) {
    this.rating = value;
  }

  setArea(value: number) {
    this.minArea = value;
  }

  setParking(value: boolean) {
    this.parking = value;
  }
}
