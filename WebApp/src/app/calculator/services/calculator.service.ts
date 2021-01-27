import {
  CalculatorApiClient,
  CreditCalculationResult,
  ECreditType,
  EPeriodType
} from "../../core/api_clients/calculator_api";
import {Injectable} from "@angular/core";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {

  constructor(private calculatorApiClient: CalculatorApiClient) {
  }

  public calculateCredit(amount: number, period: number, type: ECreditType, periodType: EPeriodType): Observable<CreditCalculationResult> {
    return this.calculatorApiClient.creditCalculator(amount, period, type, periodType);
  }
}
