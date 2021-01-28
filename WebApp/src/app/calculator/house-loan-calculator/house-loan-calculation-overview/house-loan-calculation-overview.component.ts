import {ChangeDetectionStrategy, Component, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {LoanCalculationResult} from "../../../core/api_clients/calculator_api";

@Component({
  selector: 'app-loan-calculation-overview',
  templateUrl: './house-loan-calculation-overview.component.html',
  styleUrls: ['./house-loan-calculation-overview.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HouseLoanCalculationOverviewComponent implements OnInit, OnChanges {

  @Input()
  public calculationResult: LoanCalculationResult;

  values: any[];
  view: [number, number] = [500, 200];

  gradient: boolean = true;
  showLegend: boolean = true;
  showLabels: boolean = true;
  isDoughnut: boolean = false;

  colorScheme = {
    domain: ['#5AA454', '#A10A28']
  };

  constructor() {
  }

  ngOnInit(): void {
    this.updateGraph();
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.updateGraph();
  }

  private updateGraph() {
    this.values = [
      {
        "name": "Principal",
        "value": this.calculationResult.totalPrincipal
      },
      {
        "name": "Interest",
        "value": this.calculationResult.totalInterest
      }
    ];
  }
}
