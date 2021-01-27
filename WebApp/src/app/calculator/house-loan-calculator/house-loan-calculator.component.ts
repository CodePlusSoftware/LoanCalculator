import {Component, OnInit} from '@angular/core';
import {CalculatorService} from "../services/calculator.service";
import {CalculateCreditFormModel} from "../models/calculate-credit-form-model";
import {CreditCalculationResult, ECreditType, EPeriodType} from "../../core/api_clients/calculator_api";
import {BaseComponentDirectives} from "../../core/directives/base-component-directives";
import {filter, takeUntil} from "rxjs/operators";
import {MessageService} from "primeng/api";

@Component({
  selector: 'app-house-loan-calculator',
  templateUrl: './house-loan-calculator.component.html',
  styleUrls: ['./house-loan-calculator.component.scss']
})
export class HouseLoanCalculatorComponent extends BaseComponentDirectives implements OnInit {
  public creditCalculationResult: CreditCalculationResult;

  private lastCalculatedModel: CalculateCreditFormModel

  constructor(private calculatorService: CalculatorService, private messageService: MessageService) {
    super();
  }

  ngOnInit(): void {
  }

  calculateCredit(calculateModelForm: CalculateCreditFormModel) {
    if (this.lastCalculatedModel?.loanAmount === calculateModelForm.loanAmount && this.lastCalculatedModel?.period === calculateModelForm.period) {
      return;
    }

    this.calculatorService.calculateCredit(calculateModelForm.loanAmount, calculateModelForm.period, ECreditType.House, EPeriodType.Year)
      .pipe(takeUntil(this.destroy$),
        filter(res => !!res))
      .subscribe(res => {
          this.creditCalculationResult = res;
          this.lastCalculatedModel = calculateModelForm;
        },
        err => {
          this.messageService.add({severity: 'error', summary: 'Calculation failed', detail: err})
        });
  }
}
