import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ApiService } from '../Services/api.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css'],
})
export class OrderDetailsComponent {
  carDetails: any;
  numberOfDays: number = 1; 
  totalCost: number = 0;
  endDate: Date | undefined;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private apiService: ApiService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      const carId = params.get('carId');
      if (carId !== null) {
        this.apiService.getCarById(carId).subscribe({
          next: (car) => {
            this.carDetails = car;
            this.calculateTotalCostAndEndDate(); 
          },
          error: (response) => {},
        });
      } else {
        alert('There is no car with this id');
      }
    });
  }

  calculateTotalCostAndEndDate(): void {
    
    if (this.numberOfDays > 0) {
    
      this.totalCost = this.carDetails.rentalPricePerDay * this.numberOfDays;
      const currentDate = new Date();
      this.endDate = new Date(currentDate);
      this.endDate.setDate(currentDate.getDate() + this.numberOfDays);
    } else {
      this.totalCost = 0;
      this.endDate = undefined;
      alert('Number of days cannot be negative');
    }
  }

  onNumberOfDaysChange(): void {
    this.calculateTotalCostAndEndDate();
  }

  bookCar(carDetails: any): void {
    if (this.numberOfDays > 0) {
      this.router.navigate(['/rent-agreement'], {
        queryParams: {
          carDetails: JSON.stringify(this.carDetails),
          totalCost: this.totalCost,
          endDate: this.endDate,
        },
      });
    }
  }
}
