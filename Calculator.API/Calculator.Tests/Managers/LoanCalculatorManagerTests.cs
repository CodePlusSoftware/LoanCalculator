using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Calculator.Business.Manager;
using Calculator.Business.Models;
using Calculator.Business.Services;
using Calculator.Core.Entity;
using Calculator.Dto.Dto;
using Calculator.Dto.Enum;
using Calculator.Dto.Request;
using Calculator.Dto.Response;
using FluentAssertions;
using FluentValidation;
using Moq;
using Xunit;

namespace Calculator.Tests.Managers
{
  public class LoanCalculatorManagerTests : BaseTestClass
  {
    private readonly Mock<IInstallmentService> installmentServiceMock;
    private readonly Mock<IValidator<CalculateLoanRequest>> loanCalculationValidatorMock;
    private readonly Mock<ILoanService> loanTypeServiceMock;
    private readonly ILoanCalculatorManager manager;

    public LoanCalculatorManagerTests()
    {
      loanCalculationValidatorMock = new Mock<IValidator<CalculateLoanRequest>>();
      loanTypeServiceMock = new Mock<ILoanService>();
      installmentServiceMock = new Mock<IInstallmentService>();

      manager = new LoanCalculatorManager(loanCalculationValidatorMock.Object, Logger, loanTypeServiceMock.Object,
        installmentServiceMock.Object);
    }

    [Fact]
    public async Task Calculate_ShouldConvertPeriodToMonths()
    {
      //Arrange
      var request = Fixture.Build<CalculateLoanRequest>()
        .With(x => x.Period, 2)
        .With(x => x.PeriodType, EPeriodType.Year)
        .Create();

      loanTypeServiceMock.Setup(x => x.GetLoanTypeOrFailAsync(It.IsAny<ELoanType>()))
        .ReturnsAsync(Fixture.Create<LoanTypeEntity>());
      installmentServiceMock.Setup(x =>
          x.GetInstallmentPlanAsync(It.IsAny<decimal>(), It.IsAny<int>(), It.IsAny<float>(), It.IsAny<EPaybackPlan>()))
        .ReturnsAsync(Fixture.CreateMany<Installment>().ToList());

      //Act
      _ = await manager.CalculateAsync(request);

      //Assert
      installmentServiceMock.Verify(
        x => x.GetInstallmentPlanAsync(It.IsAny<decimal>(), request.Period * 12, It.IsAny<float>(),
          It.IsAny<EPaybackPlan>()), Times.Once);
    }


    [Fact]
    public async Task Calculate_ShouldCallInstallmentServiceWithProperParameters()
    {
      //Arrange
      var request = Fixture.Create<CalculateLoanRequest>();
      var loanTypeEntity = Fixture.Create<LoanTypeEntity>();

      loanTypeServiceMock.Setup(x => x.GetLoanTypeOrFailAsync(It.IsAny<ELoanType>()))
        .ReturnsAsync(loanTypeEntity);
      installmentServiceMock.Setup(x =>
          x.GetInstallmentPlanAsync(It.IsAny<decimal>(), It.IsAny<int>(), It.IsAny<float>(), It.IsAny<EPaybackPlan>()))
        .ReturnsAsync(Fixture.CreateMany<Installment>().ToList());

      //Act
      _ = await manager.CalculateAsync(request);

      //Assert
      installmentServiceMock.Verify(
        x => x.GetInstallmentPlanAsync(request.Value, request.Period * 12, loanTypeEntity.InterestRate,
          request.PaybackPlan), Times.Once);
    }

    [Fact]
    public async Task Calculate_ShouldReturnCalculationResult()
    {
      //Arrange
      var request = Fixture.Create<CalculateLoanRequest>();
      var installments = Fixture.CreateMany<Installment>(12).ToList();

      loanTypeServiceMock.Setup(x => x.GetLoanTypeOrFailAsync(It.IsAny<ELoanType>()))
        .ReturnsAsync(Fixture.Create<LoanTypeEntity>());
      installmentServiceMock.Setup(x =>
          x.GetInstallmentPlanAsync(It.IsAny<decimal>(), It.IsAny<int>(), It.IsAny<float>(), It.IsAny<EPaybackPlan>()))
        .ReturnsAsync(installments);

      //Act
      var result = await manager.CalculateAsync(request);

      //Assert
      result.Should().BeOfType<LoanCalculationResult>();
      result.Installments.Should().HaveCount(12).And.Subject.Should().BeEquivalentTo(installments.Select(x =>
        new InstallmentDto
        {
          Interest = x.Interest,
          Principal = x.Principal,
          Payment = x.Payment,
          InstallmentDate = x.InstallmentDate
        }));

      result.TotalPrincipal.Should().Be(installments.Sum(x => x.Principal));
      result.TotalInterest = installments.Sum(x => x.Interest);
      result.TotalPayment = installments.Sum(x => x.Payment);
    }
  }
}