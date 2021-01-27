import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HouseCreditCalculatorComponent } from './house-credit-calculator.component';

describe('HouseLoanCalculatorComponent', () => {
  let component: HouseCreditCalculatorComponent;
  let fixture: ComponentFixture<HouseCreditCalculatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HouseCreditCalculatorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HouseCreditCalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
