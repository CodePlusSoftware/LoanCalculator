// // <copyright file="LoanCalculationRequestValidator.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>26-01-2021</date>
// // <summary>LoanCalculationRequestValidator.cs</summary>

using Calculator.Dto.Request;
using FluentValidation;

namespace Calculator.Business.Validators
{
  public class LoanCalculationRequestValidator: AbstractValidator<LoanCalculationRequest>
  {
    public LoanCalculationRequestValidator()
    {
      RuleFor(x => x.Amount).GreaterThan(0);
      RuleFor(x => x.Period).GreaterThan(0);
      RuleFor(x => x.Type).IsInEnum();
      RuleFor(x => x.PeriodType).IsInEnum();
    }
  }
}