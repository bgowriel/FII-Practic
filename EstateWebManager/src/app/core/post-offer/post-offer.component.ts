import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import jwtDecode from 'jwt-decode';
import { Area } from 'src/app/models/area';
import { Office } from 'src/app/models/office';
import { OfficePut } from 'src/app/models/office-put';
import { RealEstateType } from 'src/app/models/real-estate-types';
import { AreaService } from 'src/app/services/area.service';
import { ImageService } from 'src/app/services/image.service';
import { OfficeService } from 'src/app/services/office.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';


@Component({
  selector: 'app-post-offer',
  templateUrl: './post-offer.component.html',
  styleUrls: ['./post-offer.component.css']
})
export class PostOfferComponent implements OnInit {

  area!: Area;
  areas!: Area[];

  postOffer = new FormGroup({
    title: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
    contactName: new FormControl('', Validators.required),
    contactPhone: new FormControl('', Validators.required),
    contactEmail: new FormControl('', Validators.required),
    street: new FormControl('', Validators.required),
    number: new FormControl('', Validators.required),
    floor: new FormControl('', Validators.max(100)),
    door: new FormControl('', Validators.max(1000)),
    zipCode: new FormControl('', Validators.required),
    latitude: new FormControl('', Validators.min(-90) && Validators.max(90)),
    longitude: new FormControl('', Validators.min(-180) && Validators.max(180)),
    area: new FormControl('', Validators.required),
    transactionType: new FormControl('', Validators.required),
    price: new FormControl('', Validators.min(0)),
    currency: new FormControl('', Validators.required),
    rating: new FormControl('', Validators.required),
    builtUpArea: new FormControl('', Validators.required),
    ac: new FormControl('', Validators.required),
    internet: new FormControl('', Validators.required),
    parking: new FormControl('', Validators.required),
    image: new FormControl(''),
  });

  imgFile!: string;
  imgName!: string;
  imgSrc!: string;
  newFile!: File;

  officeId!: number;

  constructor(private areaService: AreaService, private imageService: ImageService, private officeService: OfficeService, private httpClient: HttpClient, private tokenService: TokenStorageService) { }

  ngOnInit(): void {
    this.loadAreas();
  }

  loadAreas(): void {
    this.areaService.getAreas().subscribe(
      data => {
        this.areas = data;
        console.log(this.areas);
      }
    );
  }

  setArea(value: Area) {
    this.area = value;
  }

  onImageChange(event: any) {
    // const reader = new FileReader();
    var blob = event.target.files[0].slice(0, event.target.files[0].size, 'image/png');
    this.newFile = new File([blob], event.target.files[0].name, { type: 'image/png' })
    
    console.log(this.newFile);

    // if (event.target.files && event.target.files[0]) {
    //   reader.readAsDataURL(event.target.files[0]);
    //   reader.onload = (e: any) => {
    //     this.imgFile = e.target.result;
    //     this.imgSrc = e.target.result;
    //     this.imgName = event.target.files[0].name;
    //     // this.postOffer.get('image')?.setValue(e.target.result);
    //   }
    // }
  }

  submitEstate() {
    // console.log(this.postOffer.value);
    let userData = this.tokenService.getUser();
    let user: any = jwtDecode(userData.token);
    console.log(user);
    console.log(user.userId);

    let office: OfficePut = {
      userId: user.userId,
      type: RealEstateType.Office,
      title: this.postOffer.get('title')?.value,
      description: this.postOffer.get('description')?.value,
      contactName: this.postOffer.get('contactName')?.value,
      contactPhone: this.postOffer.get('contactPhone')?.value,
      contactMail: this.postOffer.get('contactEmail')?.value,
      latitude: Number(this.postOffer.get('latitude')?.value),
      longitude: Number(this.postOffer.get('longitude')?.value),
      street: this.postOffer.get('street')?.value,
      number: String(this.postOffer.get('number')?.value),
      zipCode: this.postOffer.get('zipCode')?.value,
      building: "-",
      floorNumber: Number(this.postOffer.get('floor')?.value),
      doorNumber: Number(this.postOffer.get('door')?.value),
      areaId: this.area.id,
      lastUpdate: new Date(),
      transactionType: this.postOffer.get('transactionType')?.value,
      price: Number(this.postOffer.get('price')?.value),
      currency: this.postOffer.get('currency')?.value,
      periodOfTime: "month",
      rating: this.postOffer.get('rating')?.value,
      builtUpArea: Number(this.postOffer.get('builtUpArea')?.value),
      ac: this.postOffer.get('ac')?.value ? "yes" : "no",
      internet: this.postOffer.get('internet')?.value ? "yes" : "no",
      parkingPlace: this.postOffer.get('parking')?.value ? "yes" : "no",
      availableStarting: new Date(),
    }

    console.log(office);

    this.officeService.post(office).subscribe(
      data => {
        console.log(data);
        this.officeId = data.id;

        console.log(this.newFile);

        const formData = new FormData();
        formData.append('file', this.newFile);
        console.log(formData);

        this.httpClient.post<any>("https://localhost:7147/api/images", formData, { params: { "realEstateId": this.officeId } }).subscribe(
          data => {
            console.log(data);
          });

        // this.imageService.post(this.newFile, this.officeId).subscribe(
        //   data => {
        //     console.log(data);
        //     // this.imgSrc = data.fileUrl;
        //   }
        // );
      }
    );

  }
}
