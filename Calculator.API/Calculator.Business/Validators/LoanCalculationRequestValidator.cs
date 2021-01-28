using Calculator.Dto.Request;
using FluentValidation;

namespace Calculator.Business.Validators
{
  public class LoanCalculationRequestValidator: AbstractValidator<CalculateLoanRequest>
  {
    public LoanCalculationRequestValidator()
    {
      RuleFor(x => x.Value).GreaterThanOrEqualTo(1);
      RuleFor(x => x.Period).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);
      RuleFor(x => x.Type).IsInEnum().WithMessage("Invalid loan type");
      RuleFor(x => x.PeriodType).IsInEnum().WithMessage("Invalid period type");
      RuleFor(x => x.PaybackPlan).IsInEnum().WithMessage("Invalid plan");
    }
  }
}