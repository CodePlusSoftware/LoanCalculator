import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule} from "@angular/forms";
import {environment} from "../../environments/environment";
import {CALCULATOR_API_BASE_URL, CalculatorApiClient} from "./api_clients/calculator_api";
import {HttpClientModule} from "@angular/common/http";
import {PrimeNgModule} from "../prime-ng/prime-ng.module";

@NgModule({
  imports: [
    HttpClientModule,
    CommonModule,
    FormsModule,
    PrimeNgModule
  ],
  providers: [
    CalculatorApiClient,
    {provide: CALCULATOR_API_BASE_URL, useValue: environment.baseCalculatorApiUrl},
  ],
  exports: [FormsModule]
})
export class CoreModule {
}
