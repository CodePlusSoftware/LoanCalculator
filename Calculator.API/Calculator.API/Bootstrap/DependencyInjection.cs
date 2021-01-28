using System.Globalization;
using Calculator.Business.Manager;
using Calculator.Business.Services;
using Calculator.Business.Services.Strategy;
using Calculator.Core;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.API.Bootstrap
{
  public static class DependencyInjection
  {
    public static IServiceCollection RegisterDependencies(this IServiceCollection serviceCollection)
      => serviceCollection
        .RegisterManagers()
        .RegisterServices()
        .RegisterValidators()
        .RegisterLoanStrategy()
        .RegisterDataBase();

    public static IServiceCollection RegisterManagers(this IServiceCollection serviceCollection)
    {
      serviceCollection.AddScoped<ILoanCalculatorManager, LoanCalculatorManager>();
      return serviceCollection;
    }
    
    public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
    {
      serviceCollection.AddScoped<ILoanTypeService, LoanTypeService>();
      serviceCollection.AddScoped<IInstallmentService, InstallmentService>();
      return serviceCollection;
    }
    
    public static IServiceCollection RegisterValidators(this IServiceCollection serviceCollection)
    {
      ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en");
      serviceCollection.AddValidatorsFromAssembly(typeof(LoanCalculatorManager).Assembly);
      
      return serviceCollection;
    }
    
    public static IServiceCollection RegisterDataBase(this IServiceCollection serviceCollection)
    {
      serviceCollection.AddDbContext<CalculatorDbContext>(
        opt =>
        {
          opt.UseInMemoryDatabase(databaseName: "TEST");
          opt.EnableDetailedErrors();
        }, ServiceLifetime.Transient);
      
      return serviceCollection;
    }
    
    public static IServiceCollection RegisterLoanStrategy(this IServiceCollection serviceCollection)
    {
      serviceCollection.AddScoped<IConstPrincipalLoanStrategy, ConstPrincipalLoanStrategy>();
      return serviceCollection;
    }
  }
}