namespace Calculator.Tests.Validators
{
  public class BaseValidatorTests<T> : BaseTestClass where T : class, new()
  {
    protected BaseValidatorTests()
    {
      Validator = new T();
    }

    protected T Validator { get; }
  }
}