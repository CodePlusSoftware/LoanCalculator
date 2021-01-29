using System;
using System.Threading.Tasks;
using AutoFixture;
using Calculator.Business.Exceptions;
using Calculator.Business.Services;
using Calculator.Core;
using Calculator.Core.Entity;
using Calculator.Dto.Enum;
using FluentAssertions;
using Xunit;

namespace Calculator.Tests.Services
{
  public class LoanServiceTests : BaseTestClass
  {
    private readonly LoanDbContext context;
    private readonly ILoanService service;

    public LoanServiceTests()
    {
      context = CreateContext();
      service = new LoanService(context);
    }

    [Fact]
    public async Task GetLoanTypeOrFailAsync_ShouldThrowItemNotFoundException_WhenLoanTypeNotFound()
    {
      //Arrange
      ELoanType type = 0;

      //Act
      Func<Task> act = () => service.GetLoanTypeOrFailAsync(type);

      //Assert
      await act.Should().ThrowAsync<ItemNotFoundException>();
    }

    [Fact]
    public async Task GetLoanTypeOrFailAsync_ShouldReturnLoanType_WhenLoanTypeExists()
    {
      //Arrange
      var type = ELoanType.House;
      var expectedLoanType = Fixture.Build<LoanTypeEntity>()
        .With(x => x.Name, type.ToString)
        .Create();

      await context.LoanType.AddAsync(expectedLoanType);
      await context.SaveChangesAsync();

      //Act
      var loanType = await service.GetLoanTypeOrFailAsync(type);

      //Assert
      loanType.Should().Be(expectedLoanType);
    }
  }
}