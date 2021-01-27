import {Component, OnInit} from '@angular/core';
import {CalculatorService} from "../services/calculator.service";
import {CalculateCreditFormModel} from "../models/calculate-credit-form-model";
import {CreditCalculationResult, ECreditType, EPeriodType} from "../../core/api_clients/calculator_api";
import {BaseComponentDirectives} from "../../core/directives/base-component-directives";
import {filter, takeUntil} from "rxjs/operators";

@Component({
  selector: 'app-house-loan-calculator',
  templateUrl: './house-credit-calculator.component.html',
  styleUrls: ['./house-credit-calculator.component.scss']
})
export class HouseCreditCalculatorComponent extends BaseComponentDirectives implements OnInit {

  public creditCalculationResult: CreditCalculationResult;

  constructor(private calculatorService: CalculatorService) {
    super();
  }

  ngOnInit(): void {
  }

  calculateCredit(form: CalculateCreditFormModel) {
    this.calculatorService.calculateCredit(form.value, form.period, ECreditType.House, EPeriodType.Year)
      .pipe(takeUntil(this.destroy$), filter(res => !!res)).subscribe(res => this.creditCalculationResult = res);
  }
}
