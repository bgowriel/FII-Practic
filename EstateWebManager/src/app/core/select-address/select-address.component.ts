import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { map, tap } from 'rxjs';
import { AreaService } from 'src/app/services/area.service';
import { OfficeService } from 'src/app/services/office.service';

@Component({
  selector: 'app-select-address',
  templateUrl: './select-address.component.html',
  styleUrls: ['./select-address.component.css']
})
export class SelectAddressComponent implements OnInit {

  countries: string[] = [];
  cities: string[] = [];
  streets: string[] = [];

  @Output() currentCountry = new EventEmitter<string>();
  @Output() currentCity = new EventEmitter<string>();
  @Output() currentStreet = new EventEmitter<string>();
  @Output() submit = new EventEmitter<string>();

  country!: string;
  city!: string;
  street!: string;

  constructor(private areaService: AreaService, private officeService: OfficeService) { }

  ngOnInit(): void {
    this.loadCountries();
  }

  loadCountries() {
    this.areaService.getAreas().subscribe(
      (areas) => areas.map(area => {
        if (!this.countries.includes(area.country)) this.countries.push(area.country)
      })
    )
  }

  loadCities(country: string) {
    this.areaService.getByCountry(country).subscribe(
      (areas) => areas.map(area => {
        if (!this.cities.includes(area.city)) this.cities.push(area.city)
      })
    )
  }

  loadStreets(city: string) {
    this.officeService.getByAddress("", city, this.country).subscribe(
      (pagedResponse) => pagedResponse.data.map(office => {
        if (!this.streets.includes(office.street)) this.streets.push(office.street)
      })
    )
  }

  setCountry(value: string) {
    this.country = value;
    this.currentCountry.emit(value);
    this.currentCity.emit("");
    this.currentStreet.emit("");
    this.cities = [];
    this.streets = [];
    this.loadCities(this.country);
  }

  setCity(value: string) {
    this.city = value;
    this.currentCity.emit(value);
    this.currentStreet.emit("");
    this.streets = [];
    this.loadStreets(this.city);
  }

  setStreet(value: string) {
    this.street = value;
    this.currentStreet.emit(value);
  }
}
