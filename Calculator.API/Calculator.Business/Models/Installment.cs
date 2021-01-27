// // <copyright file="Installment.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>27-01-2021</date>
// // <summary>Installment.cs</summary>

namespace Calculator.Business.Models
{
  public class Installment
  {
    public decimal Capital { get; set; }
    public decimal Interest { get; set; }
    public decimal Total => this.Capital + this.Interest;
  }
}