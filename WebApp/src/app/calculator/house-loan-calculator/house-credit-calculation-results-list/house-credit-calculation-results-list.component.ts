import {Component, Input, OnInit} from '@angular/core';
import {InstallmentDto} from "../../../core/api_clients/calculator_api";

@Component({
  selector: 'app-house-credit-calculation-results-list',
  templateUrl: './house-credit-calculation-results-list.component.html',
  styleUrls: ['./house-credit-calculation-results-list.component.scss']
})
export class HouseCreditCalculationResultsListComponent implements OnInit {

  public columns: any[];
  public exportColumns: any[];

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
    this.exportColumns = this.columns.map(col => ({title: col.header, dataKey: col.field}));
  }

  exportPdf() {
    const doc = new jsPDF()
    autoTable(doc, { html: '#my-table' })
    doc.save('table.pdf')
  }
}
