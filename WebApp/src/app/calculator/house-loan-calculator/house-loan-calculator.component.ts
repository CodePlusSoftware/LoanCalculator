import {Component, OnInit} from '@angular/core';
import {CalculatorService} from "../services/calculator.service";
import {CalculateCreditFormModel} from "../models/calculate-credit-form-model";
import {ELoanType, EPaybackPlan, EPeriodType, LoanCalculationResult} from "../../core/api_clients/calculator_api";
import {BaseComponentDirectives} from "../../core/directives/base-component-directives";
import {filter, takeUntil} from "rxjs/operators";
import {MessageService} from "primeng/api";

@Component({
  selector: 'app-house-loan-calculator',
  templateUrl: './house-loan-calculator.component.html',
  styleUrls: ['./house-loan-calculator.component.scss']
})
export class HouseLoanCalculatorComponent extends BaseComponentDirectives implements OnInit {

  public loanCalculationResult: LoanCalculationResult;
  public isLoading: boolean;

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
    this.isLoading = true;
    this.calculatorService.calculateCredit(calculateModelForm.loanAmount, calculateModelForm.period, ELoanType.House, EPeriodType.Year, EPaybackPlan.ConstPrincipalAmount)
      .pipe(takeUntil(this.destroy$),
        filter(res => !!res))
      .subscribe(res => {
          this.loanCalculationResult = res;
          this.lastCalculatedModel = calculateModelForm;
          this.isLoading = false
        },
        err => {
          this.messageService.add({severity: 'error', summary: 'Calculation failed', detail: err}
          );
          this.isLoading = false;
        });
  }
}
