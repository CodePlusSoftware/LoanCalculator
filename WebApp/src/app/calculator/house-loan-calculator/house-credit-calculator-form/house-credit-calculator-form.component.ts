import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {CalculateCreditFormModel} from "../../models/calculate-credit-form-model";

@Component({
  selector: 'app-house-credit-calculator-form',
  templateUrl: './house-credit-calculator-form.component.html',
  styleUrls: ['./house-credit-calculator-form.component.scss']
})
export class HouseCreditCalculatorFormComponent implements OnInit {
  public val: number = 200000;
  public period: number = 25;

  @Output()
  public onCalculate: EventEmitter<CalculateCreditFormModel> = new EventEmitter<CalculateCreditFormModel>();

  constructor() { }

  ngOnInit(): void {
  }

  calculate() {
    this.onCalculate.emit(new CalculateCreditFormModel(this.val, this.period));
  }
}
