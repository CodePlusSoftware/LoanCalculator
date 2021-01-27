// // <copyright file="PaybackPlan.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>27-01-2021</date>
// // <summary>PaybackPlan.cs</summary>

using System.Collections.Generic;

namespace Calculator.Business.Models
{
  public class PaybackPlan
  {
    public decimal TotalCapital => this.TotalInterest + this.TotalInstallment;
    public decimal TotalInterest { get; set; }
    public decimal TotalInstallment { get; set; }
    public List<Installment> Installments { get; }
  }
}