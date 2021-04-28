export namespace ToastAct{
  export class Error {
    static readonly type = '[Toast] error'
    constructor(public content: string){}
  }
}
