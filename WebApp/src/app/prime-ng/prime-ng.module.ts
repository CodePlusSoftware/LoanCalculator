import {NgModule} from '@angular/core';

import {InputNumberModule} from 'primeng/inputnumber';
import {CardModule} from 'primeng/card';
import {ToastModule} from 'primeng/toast';
import {ButtonModule} from 'primeng/button';
import {MessageService} from "primeng/api";
import {TableModule} from 'primeng/table';
import {TooltipModule} from 'primeng/tooltip';
import {SkeletonModule} from 'primeng/skeleton';

@NgModule({
  declarations: [],
  imports: [
    InputNumberModule,
    CardModule,
    ButtonModule,
    ToastModule,
    TableModule,
    TooltipModule,
    SkeletonModule
  ],
  exports: [
    InputNumberModule,
    CardModule,
    ButtonModule,
    ToastModule,
    TableModule,
    TooltipModule,
    SkeletonModule
  ],
  providers: [MessageService]
})
export class PrimeNgModule {
}
