import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RentAgreementComponent } from './rent-agreement.component';

describe('RentAgreementComponent', () => {
  let component: RentAgreementComponent;
  let fixture: ComponentFixture<RentAgreementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RentAgreementComponent]
    });
    fixture = TestBed.createComponent(RentAgreementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
