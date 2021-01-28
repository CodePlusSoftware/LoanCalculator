import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {CalculatorRoutingModule} from './calculator-routing.module';
import {HouseLoanCalculatorComponent} from './house-loan-calculator/house-loan-calculator.component';
import {HouseLoanCalculatorFormComponent} from './house-loan-calculator/house-loan-calculator-form/house-loan-calculator-form.component';
import {CoreModule} from "../core/core.module";
import {HouseLoanAmortizationScheduleComponent} from './house-loan-calculator/house-loan-amortization-schedule/house-loan-amortization-schedule.component';
import {HouseLoanCalculationOverviewComponent} from './house-loan-calculator/house-loan-calculation-overview/house-loan-calculation-overview.component';
import {PrimeNgModule} from "../prime-ng/prime-ng.module";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {NgxChartsModule} from "@swimlane/ngx-charts";


@NgModule({
  declarations: [HouseLoanCalculatorComponent, HouseLoanCalculatorFormComponent, HouseLoanAmortizationScheduleComponent, HouseLoanCalculationOverviewComponent],
  imports: [
    CommonModule,
    CalculatorRoutingModule,
    CoreModule,
    PrimeNgModule,
    BrowserAnimationsModule,
    NgxChartsModule
  ],
  exports: [HouseLoanCalculatorComponent]
})
export class CalculatorModule {
}
