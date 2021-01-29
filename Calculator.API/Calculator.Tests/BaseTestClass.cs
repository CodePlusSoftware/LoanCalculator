using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Calculator.Core;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.TestCorrelator;

namespace Calculator.Tests
{
  public class BaseTestClass
  {
    protected Fixture Fixture { get; }

    protected ITestCorrelatorContext Context { get; }
    protected ILogger Logger { get; }
    private DbContextOptions<LoanDbContext> ContextOptions;
    
    protected BaseTestClass()
    {
      Logger = new LoggerConfiguration().WriteTo.TestCorrelator().CreateLogger();
      this.Context = TestCorrelator.CreateContext();
      this.Fixture = new Fixture();
      
      ContextOptions = new DbContextOptionsBuilder<LoanDbContext>()
        .UseInMemoryDatabase(Guid.NewGuid().ToString())
        .Options;
    }

    public IEnumerable<LogEvent> GetLogEvents()
      => TestCorrelator.GetLogEventsFromContextGuid(Context.Guid);

    public LoanDbContext CreateContext()
    {
      return new LoanDbContext(ContextOptions);
    }
  }
}