import {Component, OnInit} from '@angular/core';
import {CalculatorService} from "../services/calculator.service";
import {CalculateLoanFormModel} from "../models/calculate-loan-form-model";
import {ELoanType, EPaybackPlan, EPeriodType, LoanCalculationResult} from "../../core/api_clients/calculator_api";
import {BaseComponentDirectives} from "../../core/directives/base-component-directives";
import {filter, takeUntil, tap} from "rxjs/operators";
import {MessageService} from "primeng/api";
import {CalculatorState} from "../store/calculator.state";
import {Observable} from "rxjs";
import {Select} from "@ngxs/store";

@Component({
  selector: 'app-house-loan-calculator',
  templateUrl: './house-loan-calculator.component.html',
  styleUrls: ['./house-loan-calculator.component.scss']
})
export class HouseLoanCalculatorComponent extends BaseComponentDirectives implements OnInit {

  @Select(CalculatorState.result) loanCalculationResult: Observable<LoanCalculationResult>;
  @Select(CalculatorState.isLoading) isLoading: Observable<boolean>;

  constructor(private calculatorService: CalculatorService, private messageService: MessageService) {
    super();
  }

  ngOnInit(): void {
  }

  calculateCredit(calculateModelForm: CalculateLoanFormModel) {
    this.calculatorService.calculateCredit(calculateModelForm.loanAmount, calculateModelForm.period, ELoanType.House, EPeriodType.Year, EPaybackPlan.ConstPrincipalAmount);
  }
}
