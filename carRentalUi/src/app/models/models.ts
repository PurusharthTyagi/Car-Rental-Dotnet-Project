export interface SideNavItems {
  title: string;
  link: string;
}
export enum UserType {
  admin,
  user,
}

export interface User {
  userId: number;
  name: string;
  email: string;
  phone: string;
  password: string;
  isAdmin: boolean;
}

export interface Car {
  carId: string;
  maker: string;
  model: string;
  rentalPricePerDay: number;
  isAvailable: boolean;
  registrationNo: string;
}

// rental-agreement.model.ts
export interface showAgreement {
  rentalAgreementId: string;
  carId: string;
  userId: string;
  startDate: string;
  endDate: string;
  totalCost: number;
  requestForReturn: boolean;
  returnRequestAccepted: boolean;
}

export interface Login {
  Username: string;
  Password: string;
}
