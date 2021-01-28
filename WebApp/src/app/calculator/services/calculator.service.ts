import {
  CalculatorApiClient,
  ECreditType,
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

  public calculateCredit(amount: number, period: number, type: ECreditType, periodType: EPeriodType): Observable<LoanCalculationResult> {
    return this.calculatorApiClient.loanCalculator(amount, period, type, periodType);
  }
}
