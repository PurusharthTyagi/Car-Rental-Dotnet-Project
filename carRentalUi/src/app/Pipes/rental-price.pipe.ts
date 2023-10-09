import { Pipe, PipeTransform } from '@angular/core';
import { Car } from '../models/models';

@Pipe({
  name: 'rentalPrice',
})
export class RentalPricePipe implements PipeTransform {
  transform(cars: Car[], filterPrice: number): Car[] {
    if (!filterPrice || filterPrice <= 0) {
      return cars;
    }
    return cars.filter((car) => car.rentalPricePerDay <= filterPrice);
  }
}
