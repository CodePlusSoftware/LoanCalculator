import {Subject} from "rxjs";
import {Directive, OnDestroy} from "@angular/core";

@Directive()
export abstract class BaseComponentDirectives implements OnDestroy {
  destroy$: Subject<boolean> = new Subject<boolean>();

  ngOnDestroy(): void {
    this.destroy$.next(true);
    this.destroy$.unsubscribe();
  }
}
