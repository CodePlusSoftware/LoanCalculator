using System;

namespace Calculator.Business.Exceptions
{
  public class UndefinedPlanException : Exception
  {
    public UndefinedPlanException(string message) : base(message)
    {
    }
  }
}