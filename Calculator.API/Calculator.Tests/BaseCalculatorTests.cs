// // <copyright file="BaseCalculatorTests.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>26-01-2021</date>
// // <summary>BaseCalculatorTests.cs</summary>
using AutoFixture;

namespace Calculator.Tests
{
  public class BaseCalculatorTests
  {
    public Fixture Fixture { get; }

    public BaseCalculatorTests()
    {
      this.Fixture = new Fixture();
    }
  }
}