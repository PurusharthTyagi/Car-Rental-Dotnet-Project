import { Pipe, PipeTransform } from '@angular/core';
import { Car } from '../models/models';

@Pipe({
  name: 'model',
})
export class ModelPipe implements PipeTransform {
  transform(cars: Car[], filterText: string): Car[] {
    if (!filterText) {
      return cars;
    }
    return cars.filter((car) =>
      car.model.toLowerCase().includes(filterText.toLowerCase())
    );
  }
}
