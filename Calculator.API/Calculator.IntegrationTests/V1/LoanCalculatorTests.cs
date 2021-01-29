using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Calculator.Dto.Request;
using FluentAssertions;
using Xunit;
using AutoFixture;
using Calculator.Dto.Enum;
using Calculator.IntegrationTests.Helpers;
using System.Text.Json;
using Calculator.Dto.Response;

namespace Calculator.IntegrationTests.V1
{
  public class LoanCalculatorTests : BaseIntegrationTestClass
  {
    private readonly string baseUrl;

    public LoanCalculatorTests(CalculatorApplicationFactory factory): base(factory)
    {
      baseUrl = "loan/calculator";
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10000000001)]
    public async Task LoanCalculate_ShouldReturnBadRequest_WhenValueIsInvalid(decimal value)
    {
      //Arrange
      var model = Fixture.Build<CalculateLoanRequest>()
        .With(x => x.Period, 12)
        .With(x => x.PeriodType, EPeriodType.Year)
        .With(x => x.Value, value)
        .Create();
      
      var url = baseUrl.AddHttpGetParams(model);
      var request = Factory.Server.CreateRequest(url);

      //Act
      var result = await request.GetAsync();

      //Assert
      result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(101)]
    public async Task LoanCalculate_ShouldReturnBadRequest_WhenPeriodIsInvalid(int period)
    {
      //Arrange
      var model = Fixture.Build<CalculateLoanRequest>()
        .With(x => x.Period, period)
        .With(x => x.PeriodType, EPeriodType.Year)
        .With(x => x.Value, 12)
        .Create();
      
      var url = baseUrl.AddHttpGetParams(model);
      var request = Factory.Server.CreateRequest(url);

      //Act
      var result = await request.GetAsync();

      //Assert
      result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact]
    public async Task LoanCalculate_ShouldCalculatePaybackPlan()
    {
      //Arrange
      var model = Fixture.Build<CalculateLoanRequest>()
        .With(x => x.Period, 12)
        .With(x => x.PeriodType, EPeriodType.Year)
        .With(x => x.Value, 1000)
        .With(x => x.PaybackPlan, EPaybackPlan.ConstPrincipalAmount)
        .Create();
      
      var url = baseUrl.AddHttpGetParams(model);
      var request = Factory.Server.CreateRequest(url);

      //Act
      var result = await request.GetAsync();

      //Assert
      result.StatusCode.Should().Be(HttpStatusCode.OK);
      var calculationResult = await result.ReadAs<LoanCalculationResult>();
      
      calculationResult.Installments.Should()
        .HaveCount(model.Period * 12);
      
      calculationResult.TotalPrincipal.Should().BeGreaterThan(0).And.Be(calculationResult.Installments.Sum(v => v.Principal));
      calculationResult.TotalInterest.Should().BeGreaterThan(0).And.Be(calculationResult.Installments.Sum(v => v.Interest));
      calculationResult.TotalPayment.Should().BeGreaterThan(0).And.Be(calculationResult.Installments.Sum(v => v.Payment));
    }
    
    [Fact]
    public async Task LoanCalculate_ShouldCalculateInstallments()
    {
      //Arrange
      var model = Fixture.Build<CalculateLoanRequest>()
        .With(x => x.Period, 12)
        .With(x => x.PeriodType, EPeriodType.Year)
        .With(x => x.Value, 1000)
        .With(x => x.PaybackPlan, EPaybackPlan.ConstPrincipalAmount)
        .Create();
      
      var url = baseUrl.AddHttpGetParams(model);
      var request = Factory.Server.CreateRequest(url);

      //Act
      var result = await request.GetAsync();

      //Assert
      result.StatusCode.Should().Be(HttpStatusCode.OK);
      var calculationResult = await result.ReadAs<LoanCalculationResult>();
      
      calculationResult.Installments.Should()
        .HaveCount(model.Period * 12);

      calculationResult.Installments.Should()
        .OnlyContain(x => x.Principal == model.Value / (model.Period * 12));
      
      calculationResult.Installments.Should()
        .OnlyContain(x => x.Payment == x.Interest + x.Principal);
      
      calculationResult.Installments.Should()
        .OnlyContain(x => x.InstallmentDate != default);
      
      calculationResult.Installments.Should()
        .OnlyContain(x => x.Interest > 0);
    }
  }
}