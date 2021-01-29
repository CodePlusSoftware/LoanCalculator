using System.Threading.Tasks;
using AutoFixture;
using Calculator.API.Controllers;
using Calculator.Business.Manager;
using Calculator.Dto.Request;
using Calculator.Dto.Response;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Calculator.Tests.Controllers
{
  public class LoanCalculatorControllerTests : BaseTestClass
  {
    private readonly CreditCalculatorController controller;
    private readonly Mock<ILoanCalculatorManager> loanCalculatorServiceMock;

    public LoanCalculatorControllerTests()
    {
      loanCalculatorServiceMock = new Mock<ILoanCalculatorManager>();
      controller = new CreditCalculatorController(loanCalculatorServiceMock.Object);
    }

    [Fact]
    public async Task Calculate_ShouldCallCalculatorService()
    {
      //Arrange
      var request = Fixture.Create<CalculateLoanRequest>();

      //Act
      _ = await controller.Calculate(request);

      //Assert
      loanCalculatorServiceMock.Verify(x => x.CalculateAsync(request), Times.Once);
    }

    [Fact]
    public async Task Calculate_ShouldReturnCalculatedResult()
    {
      //Arrange
      var request = Fixture.Create<CalculateLoanRequest>();
      var expectedResponse = Fixture.Create<LoanCalculationResult>();
      loanCalculatorServiceMock.Setup(x => x.CalculateAsync(request)).ReturnsAsync(expectedResponse);

      //Act
      var response = await controller.Calculate(request);

      //Assert
      var okObjectResult = (OkObjectResult) response;
      okObjectResult.Should().NotBeNull();
      okObjectResult.Value.Should().Be(expectedResponse);
    }
  }
}