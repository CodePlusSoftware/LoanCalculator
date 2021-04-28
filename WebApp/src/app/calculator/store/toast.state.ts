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
import {MessageService} from "primeng/api";
import {Toast} from "primeng/toast";
import {ToastAct} from "./toast.actions";

export class ToastStateModel {
}

const TOAST_STATE_TOKEN = new StateToken<ToastStateModel>('toast');

@State({
  name: TOAST_STATE_TOKEN,
  defaults: {
  }
})
@Injectable()
export class ToastState {
  constructor(private messageService: MessageService) {
  }

  @Action(ToastAct.Error)
  showError(ctx: StateContext<ToastStateModel>, action: ToastAct.Error) {
    this.messageService.add({severity: 'error', summary: 'Calculation failed', detail: action.content}
    );
  }
}
