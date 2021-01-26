// // <copyright file="InvalidModelException.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>26-01-2021</date>
// // <summary>InvalidModelException.cs</summary>

using System;
using System.Collections.Generic;

namespace Calculator.Business.Exceptions
{
  public class ValidationModelException: Exception
  {
    public Dictionary<string, IEnumerable<string>> ErrorMessages { get; }

    public ValidationModelException(Dictionary<string, IEnumerable<string>> errorMessages)
    {
      this.ErrorMessages = errorMessages;
    }
  }
}