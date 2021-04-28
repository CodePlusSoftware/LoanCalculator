import {ELoanType, EPaybackPlan, EPeriodType} from "../../core/api_clients/calculator_api";

export namespace Calculator{
  export class Calculate {
    static readonly type = '[Calculator] calculate'
    constructor(public amount: number, public period: number, public type: ELoanType, public periodType: EPeriodType, public paybackPlan: EPaybackPlan){}
  }
}
