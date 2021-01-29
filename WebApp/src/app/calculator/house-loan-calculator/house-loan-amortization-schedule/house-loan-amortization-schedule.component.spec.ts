import {ComponentFixture, TestBed} from '@angular/core/testing';

import {HouseLoanAmortizationScheduleComponent} from './house-loan-amortization-schedule.component';

describe('HouseCreditCalculationResultsListComponent', () => {
  let component: HouseLoanAmortizationScheduleComponent;
  let fixture: ComponentFixture<HouseLoanAmortizationScheduleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HouseLoanAmortizationScheduleComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HouseLoanAmortizationScheduleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
