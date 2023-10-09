import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from '../models/models';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  readonly url = 'https://localhost:7166/';
  constructor(private http: HttpClient) {}

  getAllCars(): Observable<Car[]> {
    return this.http.get<Car[]>(this.url + 'GetAllCars');
  }

  getCarById(carId: string): Observable<Car> {
    return this.http.get<Car>(this.url + 'GetCarByID/' + carId);
  }

  addCar(carData: any): Observable<any> {
    console.log(carData);
    return this.http.post<any>(this.url + 'AddCar', carData);
  }

  editCar(carData: any) {
    console.log(carData);
    return this.http.put(this.url + 'UpdateCar', carData);
  }

  deleteCar(carId: string): Observable<any> {
    //const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };

    return this.http.delete(this.url + 'DeleteCar?CarId=' + carId);
  }
}
