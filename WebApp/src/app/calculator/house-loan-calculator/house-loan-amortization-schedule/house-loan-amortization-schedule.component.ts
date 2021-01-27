import {Component, Input, OnInit} from '@angular/core';
import {InstallmentDto} from "../../../core/api_clients/calculator_api";

@Component({
  selector: 'app-house-credit-calculation-results-list',
  templateUrl: './house-loan-amortization-schedule.component.html',
  styleUrls: ['./house-loan-amortization-schedule.component.scss']
})
export class HouseLoanAmortizationScheduleComponent implements OnInit {

  public columns: any[];
  public rowsPerPageOptions: number[] = [60, 120, 180];

  @Input()
  public installments: InstallmentDto[]

  constructor() { }

  ngOnInit(): void {
    this.initTable();
  }

  private initTable() {
    this.columns = [
      { field: 'installmentDate', header: 'Payment date' },
      { field: 'principal', header: 'Principal' },
      { field: 'interest', header: 'Interest' },
      { field: 'payment', header: 'Payment' }
    ];
  }
}
