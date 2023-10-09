import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AgreementApiService } from '../Services/agreement-api.service';
import { showAgreement } from '../models/models';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-rent-agreement',
  templateUrl: './rent-agreement.component.html',
  styleUrls: ['./rent-agreement.component.css'],
})
export class RentAgreementComponent implements OnInit {
  carDetails: any;
  agreementData: showAgreement | undefined;
  totalCost: number | undefined;
  endDate: Date | undefined;
  startDate: Date | undefined;

  userId: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private agreementApi: AgreementApiService,
    private userService: UserService
  ) {}
  ngOnInit(): void {
    // Retrieve both carDetails and totalCost from query parameters
    this.route.queryParams.subscribe((params) => {
      if (params['carDetails'] && params['totalCost'] && params['endDate']) {
        this.carDetails = JSON.parse(params['carDetails']);
        this.totalCost = +params['totalCost']; // Convert totalCost to a number
        this.endDate = new Date(params['endDate']); // Convert endDate to a Date object
        // Set the startDate as the current date
        this.startDate = new Date();
      }
    });

    let userPayload = this.userService.decodedToken();
    this.userId = userPayload.id;
  }
  goBack(): void {
    // Navigate back to the previous view (you can adjust the route as needed)
    this.router.navigate(['/cars/warehouse']);
  }

  confirmBooking(): void {
    const agreement = {
      carId: this.carDetails.carId.toLocaleUpperCase(),
      userId: this.userId,
      startDate: this.startDate,
      endDate: this.endDate,
      totalCost: this.totalCost,
    };

    this.agreementApi.addAgreement(agreement).subscribe({
      next: (response) => {
        console.log(response);
        
      },
      error: (err) => {
        console.log(err);
      },
    });
    this.router.navigate(['cars/show-agreement']).then(() => {
      // Reload the page
      window.location.reload();
    });
    
  }
}
