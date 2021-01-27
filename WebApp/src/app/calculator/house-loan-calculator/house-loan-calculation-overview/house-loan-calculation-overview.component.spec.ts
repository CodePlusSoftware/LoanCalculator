import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HouseLoanCalculationOverviewComponent } from './house-loan-calculation-overview.component';

describe('HouseLoanCalculationOverviewComponent', () => {
  let component: HouseLoanCalculationOverviewComponent;
  let fixture: ComponentFixture<HouseLoanCalculationOverviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HouseLoanCalculationOverviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HouseLoanCalculationOverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
