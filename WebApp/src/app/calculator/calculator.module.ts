import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {CalculatorRoutingModule} from './calculator-routing.module';
import {PrimeNgModule} from "../prime-ng/prime-ng.module";
import {HouseCreditCalculatorComponent} from './house-loan-calculator/house-credit-calculator.component';
import {HouseCreditCalculatorFormComponent} from './house-loan-calculator/house-credit-calculator-form/house-credit-calculator-form.component';
import {CoreModule} from "../core/core.module";
import { HouseCreditCalculationResultsListComponent } from './house-loan-calculator/house-credit-calculation-results-list/house-credit-calculation-results-list.component';


@NgModule({
  declarations: [HouseCreditCalculatorComponent, HouseCreditCalculatorFormComponent, HouseCreditCalculationResultsListComponent],
  imports: [
    CommonModule,
    CalculatorRoutingModule,
    CoreModule,
    PrimeNgModule
  ],
  exports: [HouseCreditCalculatorComponent]
})
export class CalculatorModule {
}
