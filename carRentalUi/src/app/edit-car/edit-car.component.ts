import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Car } from '../models/models';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../Services/api.service';

@Component({
  selector: 'app-edit-car',
  templateUrl: './edit-car.component.html',
  styleUrls: ['./edit-car.component.css'],
})
export class EditCarComponent implements OnInit {
  carForm: FormGroup;
  car: Car | undefined;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private apiService: ApiService
  ) {
    this.carForm = this.fb.group({
      carId: [],
      maker: ['', Validators.required],
      model: ['', Validators.required],
      rentalPricePerDay: [1, [Validators.required, Validators.min(1)]],
      registrationNo: [0, [Validators.required, Validators.min(0)]],
      isAvailable: [true],
    });
  }

  ngOnInit(): void {
    const carData = history.state.carData as Car;
    if (carData) {
      this.car = carData;
      this.populateFormWithCarData();
    }
  }
  populateFormWithCarData(): void {
    // Populate the form controls with car data
    if (this.car) {
      this.carForm.setValue({
        carId: this.car.carId,
        maker: this.car.maker,
        model: this.car.model,
        rentalPricePerDay: this.car.rentalPricePerDay,
        registrationNo: this.car.registrationNo,
        isAvailable: this.car.isAvailable,
      });
    }
  }

  updateCar() {
    if (this.car !== null) {
      this.apiService.editCar(this.carForm.value).subscribe({
        next: (response) => {
          console.log(response);
        },
        error: (err) => {
          console.log(err);
        },
      });
      //console.log(this.carForm.value);
      this.router.navigate(['/cars/warehouse']);
    }
  }
}
