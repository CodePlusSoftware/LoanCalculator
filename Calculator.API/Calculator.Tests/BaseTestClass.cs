using System;
using System.Collections.Generic;
using AutoFixture;
using Calculator.Core;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.TestCorrelator;

namespace Calculator.Tests
{
  public class BaseTestClass
  {
    private readonly DbContextOptions<LoanDbContext> ContextOptions;

    protected BaseTestClass()
    {
      Logger = new LoggerConfiguration().WriteTo.TestCorrelator().CreateLogger();
      Context = TestCorrelator.CreateContext();
      Fixture = new Fixture();

      ContextOptions = new DbContextOptionsBuilder<LoanDbContext>()
        .UseInMemoryDatabase(Guid.NewGuid().ToString())
        .Options;
    }

    protected Fixture Fixture { get; }

    protected ITestCorrelatorContext Context { get; }
    protected ILogger Logger { get; }

    public IEnumerable<LogEvent> GetLogEvents()
    {
      return TestCorrelator.GetLogEventsFromContextGuid(Context.Guid);
    }

    public LoanDbContext CreateContext()
    {
      return new LoanDbContext(ContextOptions);
    }
  }
}