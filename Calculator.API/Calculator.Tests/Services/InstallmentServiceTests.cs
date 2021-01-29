using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Calculator.Business.Exceptions;
using Calculator.Business.Models;
using Calculator.Business.Services;
using Calculator.Business.Services.Strategy;
using Calculator.Dto.Enum;
using FluentAssertions;
using Moq;
using Xunit;

namespace Calculator.Tests.Services
{
  public class InstallmentServiceTests : BaseTestClass
  {
    private readonly Mock<IConstPrincipalLoanStrategy> constPrincipalLoanStrategyMock;
    private readonly IInstallmentService service;

    public InstallmentServiceTests()
    {
      constPrincipalLoanStrategyMock = new Mock<IConstPrincipalLoanStrategy>();
      service = new InstallmentService(constPrincipalLoanStrategyMock.Object);
    }

    [Fact]
    public async Task Generate_ShouldThrowUndefinedPlanException_WhenPayBackPlanIsInvalid()
    {
      //Arrange
      var amount = Fixture.Create<decimal>();
      var months = Fixture.Create<int>();
      var interestRate = Fixture.Create<float>();
      EPaybackPlan plan = 0;

      //Act
      Func<Task> act = () => service.GetInstallmentPlanAsync(amount, months, interestRate, plan);

      //Assert
      await act.Should().ThrowAsync<UndefinedPlanException>();
    }

    [Fact]
    public async Task Generate_ShouldInvokeConstPrincipalLoanStrategy_WhenPayBackPlanIsConstPrincipalAmount()
    {
      //Arrange
      var amount = Fixture.Create<decimal>();
      var months = Fixture.Create<int>();
      var interestRate = Fixture.Create<float>();
      var plan = EPaybackPlan.ConstPrincipalAmount;
      var expectedInstallments = Fixture.CreateMany<Installment>(10).ToList();

      constPrincipalLoanStrategyMock.Setup(x => x.Generate(amount, months, interestRate))
        .Returns(expectedInstallments);

      //Act
      var installments = await service.GetInstallmentPlanAsync(amount, months, interestRate, plan);

      //Assert
      constPrincipalLoanStrategyMock.Verify(x => x.Generate(amount, months, interestRate), Times.Once);
      installments.Should().BeEquivalentTo(expectedInstallments);
    }
  }
}