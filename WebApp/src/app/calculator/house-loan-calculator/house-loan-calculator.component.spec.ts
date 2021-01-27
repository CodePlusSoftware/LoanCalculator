import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HouseLoanCalculatorComponent } from './house-loan-calculator.component';

describe('HouseLoanCalculatorComponent', () => {
  let component: HouseLoanCalculatorComponent;
  let fixture: ComponentFixture<HouseLoanCalculatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HouseLoanCalculatorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HouseLoanCalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
