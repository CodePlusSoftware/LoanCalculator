using System.Collections.Generic;
using AutoFixture;
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

    protected BaseTestClass()
    {
      Logger = new LoggerConfiguration().WriteTo.TestCorrelator().CreateLogger();
      this.Context = TestCorrelator.CreateContext();
      this.Fixture = new Fixture();
    }

    public IEnumerable<LogEvent> GetLogEvents()
      => TestCorrelator.GetLogEventsFromContextGuid(Context.Guid);
  }
}