import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Office } from 'src/app/models/office';

// var mapboxgl = require('mapbox-gl/dist/mapbox-gl.js');
// mapboxgl.accessToken = 'pk.eyJ1IjoiYmdvd3JpZWwiLCJhIjoiY2w5ZHhnMXNtMGswZTN4b2dnM2MwMXd0OSJ9.g_0gI0urJFG2i-8j3zM3Ow';

@Component({
  selector: 'app-estate-details',
  templateUrl: './estate-details.component.html',
  styleUrls: ['./estate-details.component.css']
})
export class EstateDetailsComponent implements OnInit {
  @Input() office!: Office;
  //@ViewChild('#geolocation')
    
  constructor() { }

  ngOnInit(): void {
    // var map = new mapboxgl.Map({
    //   container: 'geolocation',
    //   style: 'mapbox://styles/mapbox/streets-v11'
    // });
    
  }

}
