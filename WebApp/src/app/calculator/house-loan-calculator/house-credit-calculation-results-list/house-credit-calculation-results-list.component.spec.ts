import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HouseCreditCalculationResultsListComponent } from './house-credit-calculation-results-list.component';

describe('HouseCreditCalculationResultsListComponent', () => {
  let component: HouseCreditCalculationResultsListComponent;
  let fixture: ComponentFixture<HouseCreditCalculationResultsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HouseCreditCalculationResultsListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HouseCreditCalculationResultsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
