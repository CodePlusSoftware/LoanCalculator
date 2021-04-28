import {
  CalculatorApiClient,
  ELoanType,
  EPaybackPlan,
  EPeriodType,
  LoanCalculationResult
} from "../../core/api_clients/calculator_api";
import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {Store} from "@ngxs/store";
import {Calculator} from "../store/calculator.actions";

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {

  constructor(private store: Store) {
  }

  public calculateCredit(amount: number, period: number, type: ELoanType, periodType: EPeriodType, paybackPlan: EPaybackPlan): Observable<LoanCalculationResult> {
    return this.store.dispatch(new Calculator.Calculate(amount, period, type, periodType, paybackPlan));
  }
}
