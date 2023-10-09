import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Car } from '../models/models';
import { ApiService } from '../Services/api.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-warehouse',
  templateUrl: './warehouse.component.html',
  styleUrls: ['./warehouse.component.css'],
})
export class WarehouseComponent {
  carsToDisplay: Car[] = [];
  displayedColumns: string[] = [
    'carId',
    'maker',
    'model',
    'rentalPricePerDay',
    'isAvailable',
    'registrationNo',
    'Action',
  ];

  filterTerm: string = '';
  filterText: string = '';
  filterPrice: any;

  roles: any;

  constructor(
    private router: Router,
    private apiService: ApiService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.apiService.getAllCars().subscribe({
      next: (cars) => {
        this.carsToDisplay = cars;
      },
      error: (response) => {
        console.log(response);
      },
    });
  }

  orderCar(car: any): void {
    if (car.isAvailable) {
      if (this.isThere()) {
        this.router.navigate(['/order-details', car.carId]);
      } else {
        alert('Please login to order a car.');
        this.router.navigate(['/login']);
      }
    } else {
      alert('This car is not available for order.');
    }
  }

  AddCar() {
    this.router.navigate(['/cars/add-car']);
  }

  editCar(car: Car) {
    this.router.navigate(['/cars/edit-car', car.carId], {
      state: { carData: car },
    });
  }

  deleteCar(car: any): void {
    alert('Are you sure you want to delete ?');
    const carIndex = car.carId;
    this.apiService.deleteCar(carIndex).subscribe({
      next: (response) => {
        this.carsToDisplay.splice(carIndex, 1);
        console.log(response);
      },

      error: (response) => {
        console.log(response);
      },
    });
  }

  isThere(): Boolean {
    if (localStorage.getItem('token')) {
      return true;
    }
    return false;
  }

  checkForAdminRole(): Boolean {
    let userPayload = this.userService.decodedToken();
    if (userPayload) {
      this.roles = userPayload.isAdmin || '';
      if (this.roles == 'Admin') {
        return true;
      } else {
        return false;
      }
    }
    return false;
  }
}
