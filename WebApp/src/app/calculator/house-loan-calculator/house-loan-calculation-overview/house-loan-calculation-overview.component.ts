import {ChangeDetectionStrategy, Component, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {LoanCalculationResult} from "../../../core/api_clients/calculator_api";

@Component({
  selector: 'app-loan-calculation-overview',
  templateUrl: './house-loan-calculation-overview.component.html',
  styleUrls: ['./house-loan-calculation-overview.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HouseLoanCalculationOverviewComponent implements OnInit, OnChanges {
  public values: any[];
  public view: [number, number] = [500, 200];

  public showLegend: boolean = true;
  public showLabels: boolean = true;
  public isDoughnut: boolean = false;

  public colorScheme = {
    domain: ['#5AA454', '#A10A28']
  };

  public estimatedPayoffDate: Date;
  public estimatedPayments: number;

  @Input()
  public calculationResult: LoanCalculationResult;

  constructor() {
  }

  ngOnInit(): void {
    this.updateGraph();
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.updateGraph();
    this.updateLoanDetails();
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

  private updateLoanDetails() {
    this.estimatedPayoffDate = this.calculationResult.installments[this.calculationResult.installments.length - 1].installmentDate;
    this.estimatedPayments = this.calculationResult.installments.length;
  }
}
