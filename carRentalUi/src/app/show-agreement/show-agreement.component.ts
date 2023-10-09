import { Component } from '@angular/core';
import { showAgreement } from '../models/models';
import { ActivatedRoute, Router } from '@angular/router';
import { AgreementApiService } from '../Services/agreement-api.service';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-show-agreement',
  templateUrl: './show-agreement.component.html',
  styleUrls: ['./show-agreement.component.css'],
})
export class ShowAgreementComponent {
  agreementToDisplay: showAgreement[] = [];
  roles: any;
  userId: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private agreementApi: AgreementApiService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    let userPayload = this.userService.decodedToken();
    if (userPayload) {
      this.roles = userPayload.isAdmin || '';
      this.userId = userPayload.id;
      if (this.roles == 'Admin') {
        this.agreementApi.getAllAgreements().subscribe({
          next: (agreements) => {
            this.agreementToDisplay = agreements;
          },
          error: (response) => {
            console.log(response);
          },
        });
      } else {
        this.agreementApi.getAgreementByUserId(this.userId).subscribe({
          next: (agreements) => {
            this.agreementToDisplay = agreements;
          },
          error: (response) => {},
        });
      }
    }
  }

  returnCar(rentalAgreementId: any) {
    this.agreementApi.requestForReturn(rentalAgreementId).subscribe({
      next: (response) => {
        console.log(response);
        alert('Requested for the Return !');
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  approveReturnCar(rentalAgreementId: any) {
    this.agreementApi.requestForReturnApproved(rentalAgreementId).subscribe({
      next: (response) => {
        console.log(response);
        this.router.navigate(['cars/warehouse']);
      },
      error: (err) => {
        console.log(err);
      },
    });
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
