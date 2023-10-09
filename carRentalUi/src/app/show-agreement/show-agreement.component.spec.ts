import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowAgreementComponent } from './show-agreement.component';

describe('ShowAgreementComponent', () => {
  let component: ShowAgreementComponent;
  let fixture: ComponentFixture<ShowAgreementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShowAgreementComponent]
    });
    fixture = TestBed.createComponent(ShowAgreementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
