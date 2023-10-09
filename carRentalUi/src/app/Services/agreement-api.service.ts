import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { showAgreement } from '../models/models';

@Injectable({
  providedIn: 'root',
})
export class AgreementApiService {
  readonly url = 'https://localhost:7166/';
  constructor(private http: HttpClient) {}

  getAllAgreements(): Observable<showAgreement[]> {
    return this.http.get<showAgreement[]>(this.url + 'GetAllAgreement');
  }

  getAgreementByUserId(userId: string): Observable<showAgreement[]> {
    return this.http.get<showAgreement[]>(
      this.url + 'AgreementByUserId?userId=' + userId
    );
  }

  addAgreement(agreement: any): Observable<any> {
    console.log(agreement);
    return this.http.post<any>(
      this.url +
        'AddAgreement?CarId=' +
        agreement.carId +
        '&UserId=' +
        agreement.userId +
        '&StartDate=' +
        agreement.startDate.toLocaleString() +
        '&EndDate=' +
        agreement.endDate.toLocaleString() +
        '&TotalCost=' +
        agreement.totalCost,
      agreement
    );
  }

  requestForReturn(rentalAgreementId: any): Observable<any> {
    return this.http.put<any>(
      this.url + 'RequestForReturn?rentalagreementId=' + rentalAgreementId,
      rentalAgreementId
    );
  }

  requestForReturnApproved(rentalAgreementId: any): Observable<any> {
    return this.http.put<any>(
      this.url +
        'AcceptRequestForReturn?rentalagreementId=' +
        rentalAgreementId,
      rentalAgreementId
    );
  }
}
