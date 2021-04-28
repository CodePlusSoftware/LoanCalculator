import {
  CalculatorApiClient,
  ELoanType,
  EPaybackPlan,
  EPeriodType,
  LoanCalculationResult
} from "../../core/api_clients/calculator_api";
import {Action, Selector, State, StateContext, StateToken} from "@ngxs/store";
import {Injectable} from "@angular/core";
import {Calculator} from "./calculator.actions";
import {catchError, tap} from "rxjs/operators";
import {EMPTY} from "rxjs";
import {ToastAct} from "./toast.actions";

export class CalculatorStateModel {
  isLoading: boolean;
  amount: number;
  period: number;
  type: ELoanType;
  periodType: EPeriodType;
  paybackPlan: EPaybackPlan;
  result: LoanCalculationResult;
}

const CALCULATOR_STATE_TOKEN = new StateToken<CalculatorStateModel>('calculator');

@State({
  name: CALCULATOR_STATE_TOKEN,
  defaults: {
    isLoading: false,
    amount: 0,
    period: 0,
    type: ELoanType.House,
    paybackPlan: EPaybackPlan.ConstPrincipalAmount,
    periodType: EPeriodType.Year,
    result: null
  }
})
@Injectable()
export class CalculatorState {
  constructor(private calculatorApiClient: CalculatorApiClient) {
  }

  @Action(Calculator.Calculate)
  feedAnimals(ctx: StateContext<CalculatorStateModel>, action: Calculator.Calculate) {
    const state = ctx.getState();
    debugger;
    if (action.amount == state.amount && action.period == state.period) return EMPTY;
    ctx.patchState({
      ...state,
      isLoading: true,
      amount: action.amount,
      type: action.type,
      periodType: action.periodType,
      period: action.period,
      paybackPlan: action.paybackPlan,
    });
    return this.calculatorApiClient.loanCalculator(action.amount, action.period, action.type, action.periodType, action.paybackPlan).pipe(tap(result => ctx.patchState({
      ...state,
      result,
      isLoading: false
    })), catchError(_ => {
      ctx.patchState({...state, isLoading: false});
      return ctx.dispatch(new ToastAct.Error('Calculation failed'));
    }));
  }

  @Selector()
  static result(state: CalculatorStateModel) {
    return state.result;
  }

  @Selector()
  static isLoading(state: CalculatorStateModel) {
    return state.isLoading;
  }
}
