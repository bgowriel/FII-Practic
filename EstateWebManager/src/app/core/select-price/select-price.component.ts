import { Component, EventEmitter, Input, OnInit, Output, ViewChild, ViewChildren } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatInput } from '@angular/material/input';
import { AreaService } from 'src/app/services/area.service';

@Component({
  selector: 'app-select-price',
  templateUrl: './select-price.component.html',
  styleUrls: ['./select-price.component.css']
})
export class SelectPriceComponent implements OnInit {

  cities: string[] = [];

  @Input() minimum!: number;
  @Input() maximum!: number;

  @Output() currentCity = new EventEmitter<string>();
  @Output() currency = new EventEmitter<string>();
  @Output() minPrice = new EventEmitter<number>();
  @Output() maxPrice = new EventEmitter<number>();
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

  setCurrency(value: string) {
    this.currency.emit(value);
  }

  setCity(value: string) {
    this.currentCity.emit(value);
  }
}
