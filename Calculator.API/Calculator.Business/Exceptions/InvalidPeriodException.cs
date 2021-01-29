using System;

namespace Calculator.Business.Exceptions
{
  public class InvalidPeriodException : Exception
  {
    public InvalidPeriodException() : base("Invalid Period")
    {
    }
  }
}