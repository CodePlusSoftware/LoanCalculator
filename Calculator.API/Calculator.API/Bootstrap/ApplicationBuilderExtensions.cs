using System.Linq;
using Calculator.Core;
using Calculator.Core.Entity;
using Calculator.Dto.Enum;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.API.Bootstrap
{
  public static class ApplicationBuilderExtensions
  {
    //TEST DB SOLUTION
    public static IApplicationBuilder SeedData(this IApplicationBuilder builder)
    {
      using var serviceScope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
      using var context = serviceScope.ServiceProvider.GetService<LoanDbContext>();
      context.Seed();

      return builder;
    }


  private static void Seed(this LoanDbContext context)
  {
    if (context.LoanType.Any()) return;
    
    context.LoanType.AddAsync(new LoanTypeEntity {Id = 1, Name = ELoanType.House.ToString(), Description = "House loan entity", InterestRate = 3.5f});
    context.SaveChanges();

  }
  }
}