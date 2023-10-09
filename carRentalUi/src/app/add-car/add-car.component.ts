import { Component } from '@angular/core';
import { Car } from '../models/models';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../Services/api.service';

@Component({
  selector: 'app-add-car',
  templateUrl: './add-car.component.html',
  styleUrls: ['./add-car.component.css'],
})
export class AddCarComponent {
  newCarForm: FormGroup; // Define a FormGroup for your form

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private apiService: ApiService
  ) {
    // Initialize the form with validators
    this.newCarForm = this.formBuilder.group({
      maker: ['', Validators.required],
      model: ['', Validators.required],
      rentalPricePerDay: [0, [Validators.required, Validators.min(1)]],
      registrationNo: ['', Validators.required],
    });
  }

  addCar(): void {
    // Implement logic to add the new car (e.g., send it to a service or API)
    if (this.newCarForm !== null) {
      this.apiService.addCar(this.newCarForm.value).subscribe({
        next: (response) => {
          console.log(response);
        },
        error: (err) => {
          console.log(err);
        },
      });
      alert('The car is added');
      this.router.navigateByUrl('/cars/warehouse');
    }
  }
}
