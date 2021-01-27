import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HouseLoanCalculatorFormComponent } from './house-loan-calculator-form.component';

describe('HouseLoanCalculatorFormComponent', () => {
  let component: HouseLoanCalculatorFormComponent;
  let fixture: ComponentFixture<HouseLoanCalculatorFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HouseLoanCalculatorFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HouseLoanCalculatorFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
