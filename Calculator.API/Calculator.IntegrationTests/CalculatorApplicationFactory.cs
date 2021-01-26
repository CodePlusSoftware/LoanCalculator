// // <copyright file="WebApplicationFactory.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>26-01-2021</date>
// // <summary>WebApplicationFactory.cs</summary>

using Calculator.API;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Calculator.IntegrationTests
{
  public class CalculatorApplicationFactory: WebApplicationFactory<Startup>
  {
  }
}