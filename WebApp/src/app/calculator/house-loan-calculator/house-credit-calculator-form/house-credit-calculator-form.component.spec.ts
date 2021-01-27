import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HouseCreditCalculatorFormComponent } from './house-credit-calculator-form.component';

describe('HouseLoanCalculatorFormComponent', () => {
  let component: HouseCreditCalculatorFormComponent;
  let fixture: ComponentFixture<HouseCreditCalculatorFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HouseCreditCalculatorFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HouseCreditCalculatorFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
