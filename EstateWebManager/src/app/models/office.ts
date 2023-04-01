import { RealEstateType } from "./real-estate-types";
import { Image } from "./image";

export interface Office {
    id: number;
    userId: string;
    type: RealEstateType;
    title: string;
    description: string;
    contactName: string;
    contactPhone: string;
    contactMail: string;
    latitude: number;
    longitude: number;
    street: string;
    number: string;
    zipCode: string;
    building: string;
    floorNumber: number;
    doorNumber: number;
    areaId: number;
    lastUpdate: Date;
    transactionType: string;
    price: number;
    currency: string;
    periodOfTime: string;
    rating: string;
    builtUpArea: number;
    ac: string;
    internet: string;
    parkingPlace: string;
    availableStarting: Date;
    images: Image[];
}