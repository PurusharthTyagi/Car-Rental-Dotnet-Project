import { Pipe, PipeTransform } from '@angular/core';
import { Car } from '../models/models';

@Pipe({
  name: 'maker',
})
export class MakerPipe implements PipeTransform {
  transform(cars: Car[], filterTerm: string): Car[] {
    if (!filterTerm) {
      return cars;
    }
    return cars.filter((car) =>
      car.maker.toLowerCase().includes(filterTerm.toLowerCase())
    );
  }
}
