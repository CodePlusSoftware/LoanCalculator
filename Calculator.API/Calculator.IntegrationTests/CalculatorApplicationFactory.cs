using Calculator.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace Calculator.IntegrationTests
{
  public class CalculatorApplicationFactory: WebApplicationFactory<Startup>
  {
    protected override IHost CreateHost(IHostBuilder builder)
    {
      return base.CreateHost(builder);
    }
  }
}