import { RealEstateType } from "./real-estate-types";

export interface Land {
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
    landArea: number;
    topography: string;
    fence: string;
    currentStatus: string;
    electricity: string;
    water: string;
    sewerage: string;
    heating: string;
    availableStarting: Date;
}