using AutoFixture;
using Calculator.Business.Validators;
using Calculator.Dto.Enum;
using Calculator.Dto.Request;
using FluentValidation.TestHelper;
using Xunit;

namespace Calculator.Tests.Validators
{
  public class LoanCalculationRequestValidatorTests : BaseValidatorTests<LoanCalculationRequestValidator>
  {
    [Theory]
    [InlineData(null)]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(50)]
    [InlineData(999)]
    [InlineData(10000000001)]
    public void ValidateAndThrowAsync_ShouldHaveValidationError_WhenLoanAmountIsInvalid(decimal amount)
    {
      var command = Fixture.Build<CalculateLoanRequest>()
        .With(x => x.Value, amount)
        .Create();

      Validator.ShouldHaveValidationErrorFor(x => x.Value, command);
    }

    [Theory]
    [InlineData(1000)]
    [InlineData(10000)]
    [InlineData(1000000)]
    [InlineData(10000000000)]
    public void ValidateAndThrowAsync_ShouldNotHaveValidationError_WhenLoanAmountIsValid(decimal amount)
    {
      var command = Fixture.Build<CalculateLoanRequest>()
        .With(x => x.Value, amount)
        .Create();

      Validator.ShouldNotHaveValidationErrorFor(x => x.Value, command);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(101)]
    [InlineData(1000)]
    public void ValidateAndThrowAsync_ShouldHaveValidationError_WhenLoanPeriodIsInvalid(int period)
    {
      var command = Fixture.Build<CalculateLoanRequest>()
        .With(x => x.Period, period)
        .Create();

      Validator.ShouldHaveValidationErrorFor(x => x.Period, command);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(25)]
    [InlineData(100)]
    public void ValidateAndThrowAsync_ShouldNotHaveValidationError_WhenLoanPeriodIsValid(int period)
    {
      var command = Fixture.Build<CalculateLoanRequest>()
        .With(x => x.Period, period)
        .Create();

      Validator.ShouldNotHaveValidationErrorFor(x => x.Period, command);
    }

    [Fact]
    public void ValidateAndThrowAsync_ShouldHaveValidationError_WhenLoanTypeInvalid()
    {
      ELoanType type = 0;
      var command = Fixture.Build<CalculateLoanRequest>()
        .With(x => x.Type, type)
        .Create();

      Validator.ShouldHaveValidationErrorFor(x => x.Type, command);
    }

    [Theory]
    [InlineData(ELoanType.House)]
    public void ValidateAndThrowAsync_ShouldNotHaveValidationError_WhenLoanTypeIsValid(ELoanType type)
    {
      var command = Fixture.Build<CalculateLoanRequest>()
        .With(x => x.Type, type)
        .Create();

      Validator.ShouldNotHaveValidationErrorFor(x => x.Type, command);
    }

    [Fact]
    public void ValidateAndThrowAsync_ShouldHaveValidationError_WhenPeriodTypeInvalid()
    {
      EPeriodType type = 0;
      var command = Fixture.Build<CalculateLoanRequest>()
        .With(x => x.PeriodType, type)
        .Create();

      Validator.ShouldHaveValidationErrorFor(x => x.PeriodType, command);
    }

    [Theory]
    [InlineData(EPeriodType.Year)]
    public void ValidateAndThrowAsync_ShouldNotHaveValidationError_WhenPeriodTypeIsValid(EPeriodType type)
    {
      var command = Fixture.Build<CalculateLoanRequest>()
        .With(x => x.PeriodType, type)
        .Create();

      Validator.ShouldNotHaveValidationErrorFor(x => x.PeriodType, command);
    }

    [Fact]
    public void ValidateAndThrowAsync_ShouldHaveValidationError_WhenPaybackPlanInvalid()
    {
      EPaybackPlan plan = 0;
      var command = Fixture.Build<CalculateLoanRequest>()
        .With(x => x.PaybackPlan, plan)
        .Create();

      Validator.ShouldHaveValidationErrorFor(x => x.PaybackPlan, command);
    }

    [Theory]
    [InlineData(EPaybackPlan.ConstPrincipalAmount)]
    public void ValidateAndThrowAsync_ShouldNotHaveValidationError_WhenPaybackPlanIsValid(EPaybackPlan plan)
    {
      var command = Fixture.Build<CalculateLoanRequest>()
        .With(x => x.PaybackPlan, plan)
        .Create();

      Validator.ShouldNotHaveValidationErrorFor(x => x.PaybackPlan, command);
    }
  }
}