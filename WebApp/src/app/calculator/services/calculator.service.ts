import {
  CalculatorApiClient,
  ELoanType,
  EPaybackPlan,
  EPeriodType,
  LoanCalculationResult
} from "../../core/api_clients/calculator_api";
import {Injectable} from "@angular/core";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {

  constructor(private calculatorApiClient: CalculatorApiClient) {
  }

  public calculateCredit(amount: number, period: number, type: ELoanType, periodType: EPeriodType, paybackPlan: EPaybackPlan): Observable<LoanCalculationResult> {
    return this.calculatorApiClient.loanCalculator(amount, period, type, periodType, paybackPlan);
  }
}
