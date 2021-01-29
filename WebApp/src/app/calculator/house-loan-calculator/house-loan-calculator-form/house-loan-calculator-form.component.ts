import {ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {CalculateLoanFormModel} from "../../models/calculate-loan-form-model";

@Component({
  selector: 'app-house-credit-calculator-form',
  templateUrl: './house-loan-calculator-form.component.html',
  styleUrls: ['./house-loan-calculator-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HouseLoanCalculatorFormComponent implements OnInit {
  public val: number = 200000;
  public period: number = 25;

  @Input()
  public isLoading: boolean;

  @Output()
  public onCalculate: EventEmitter<CalculateLoanFormModel> = new EventEmitter<CalculateLoanFormModel>();

  constructor() {
  }

  ngOnInit(): void {
  }

  calculate() {
    this.onCalculate.emit(new CalculateLoanFormModel(this.val, this.period));
  }
}
