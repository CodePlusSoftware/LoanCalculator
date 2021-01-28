namespace Calculator.Tests.Validators
{
  public class BaseValidatorTests<T>: BaseTestClass where T : class, new()
  {
    protected T Validator { get; }

    protected BaseValidatorTests()
    {
      this.Validator = new T();
    }
  }
}