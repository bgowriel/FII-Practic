import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { AreaService } from 'src/app/services/area.service';



@Component({
  selector: 'app-search-with-options',
  templateUrl: './search-with-options.component.html',
  styleUrls: ['./search-with-options.component.css']
})
export class SearchWithOptionsComponent implements OnInit {

  cities: string[] = [];
  
  @Output() acChecked = new EventEmitter<boolean>();
  @Output() internetChecked = new EventEmitter<boolean>();
  @Output() parkingChecked = new EventEmitter<boolean>();
  @Input() minArea!: number;
  @Output() minimumArea = new EventEmitter<number>();
  @Output() rating = new EventEmitter<string>();
  @Output() currentCity = new EventEmitter<string>();
  @Output() submit = new EventEmitter<string>();


  constructor(private areaService: AreaService) { }

  ngOnInit(): void {
    this.loadAllCities();
  }

  loadAllCities() {
    this.areaService.getAreas().subscribe(
      (areas) => areas.map(area => {
        if (!this.cities.includes(area.country)) this.cities.push(area.city)
      })
    )
  }

  setRating(value: string) {
    this.rating.emit(value);
  }

  setCity(value: string) {
    this.currentCity.emit(value);
  }

}
