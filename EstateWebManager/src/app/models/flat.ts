import { RealEstateType } from "./real-estate-types";

export interface Flat {
    id: number;
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
    builtUpArea: number;
    bedrooms: number;
    bathrooms: number;
    heating: string;
    ac: string;
    internet: string;
    parkingPlace: string;
    availableStarting: Date;
}