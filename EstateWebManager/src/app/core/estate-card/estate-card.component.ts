import { Component, Input, OnInit } from '@angular/core';


@Component({
  selector: 'app-estate-card',
  templateUrl: './estate-card.component.html',
  styleUrls: ['./estate-card.component.css']
})
export class EstateCardComponent implements OnInit {
  @Input() estate: any;

  constructor() { }

  ngOnInit(): void {
  }

}
