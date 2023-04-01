import { Component, OnInit } from '@angular/core';
import { Flat } from '../models/flat';
import { FlatService } from '../services/flat.service';

@Component({
  selector: 'ewm-flat',
  templateUrl: './flat.component.html',
  styleUrls: ['./flat.component.css'],
})
export class FlatComponent implements OnInit {
  flats: Flat[] = [];

  constructor(private flatService: FlatService) {}

  ngOnInit(): void {
    //code that needs to be done after component is initialized
  }

}
