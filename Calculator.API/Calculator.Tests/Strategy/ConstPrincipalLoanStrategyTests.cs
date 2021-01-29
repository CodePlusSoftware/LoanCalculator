using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.Business.Exceptions;
using Calculator.Business.Models;
using Calculator.Business.Services.Strategy;
using FluentAssertions;
using Xunit;

namespace Calculator.Tests.Strategy
{
  public class ConstPrincipalLoanStrategyTests : BaseTestClass
  {
    private readonly IConstPrincipalLoanStrategy strategy;

    public ConstPrincipalLoanStrategyTests()
    {
      strategy = new ConstPrincipalLoanStrategy();
    }

    [Fact]
    public async Task Generate_ShouldThrowItemNotFoundException_WhenLoanTypeNotFound()
    {
      //Arrange
      var totalAmount = 1.0m;
      var months = 0;
      var interestRatePercentage = 1.0f;

      //Act
      Func<IEnumerable<Installment>> act = () => strategy.Generate(totalAmount, months, interestRatePercentage);

      //Assert
      act.Should().Throw<InvalidPeriodException>();
    }

    [Fact]
    public async Task Generate_ShouldGenerateProperNumberOfInstallments()
    {
      //Arrange
      const decimal totalAmount = 1.0m;
      const int months = 12;
      const float interestRatePercentage = 1.0f;

      //Act
      var installments = strategy.Generate(totalAmount, months, interestRatePercentage);

      //Assert
      installments.Should().HaveCount(months);
    }

    [Fact]
    public async Task Generate_ShouldGenerateConstPrincipalInstallmentAmount()
    {
      //Arrange
      const decimal totalAmount = 1000.0m;
      const int months = 12;
      const float interestRatePercentage = 1.0f;
      var expectedPrincipalAmount = totalAmount / months;

      //Act
      var installments = strategy.Generate(totalAmount, months, interestRatePercentage);

      //Assert
      installments.Should().OnlyContain(x => x.Principal == expectedPrincipalAmount);
    }

    [Fact]
    public async Task Generate_ShouldGenerateCorrectInstallmentDate()
    {
      //Arrange
      const decimal totalAmount = 1000.0m;
      const int months = 12;
      const float interestRatePercentage = 1.0f;
      var expectedPaymentDates = Enumerable.Range(0, months).Select(x => DateTime.Now.AddMonths(x).Date);

      //Act
      var installments = strategy.Generate(totalAmount, months, interestRatePercentage);

      //Assert
      installments.Select(x => x.InstallmentDate.Date).Should().BeEquivalentTo(expectedPaymentDates);
    }

    [Fact]
    public async Task Generate_ShouldGenerateCorrectInterests()
    {
      //Arrange
      const decimal totalAmount = 1000.0m;
      const int months = 12;
      const float interestRatePercentage = 1.0f;
      var expectedInterests = Enumerable.Range(0, months)
        .Select(x =>
          ((totalAmount - x * totalAmount / months) * (decimal) (interestRatePercentage / 100) / 12).ToString("#.##"));

      //Act
      var installments = strategy.Generate(totalAmount, months, interestRatePercentage);

      //Assert
      installments.Select(x => x.Interest.ToString("#.##")).Should().BeEquivalentTo(expectedInterests);
    }
  }
}