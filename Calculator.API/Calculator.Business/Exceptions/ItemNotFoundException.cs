using System;

namespace Calculator.Business.Exceptions
{
  public class ItemNotFoundException : Exception
  {
    public ItemNotFoundException(string message) : base(message)
    {
    }
  }
}