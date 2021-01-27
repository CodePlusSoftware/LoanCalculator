// // <copyright file="InstallmentDto.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>27-01-2021</date>
// // <summary>InstallmentDto.cs</summary>

using System;

namespace Calculator.Dto.Dto
{
  public class InstallmentDto
  {
    public decimal Principal { get; set; }
    public decimal Interest { get; set; }
    public DateTime InstallmentDate { get; set; }
    public decimal Payment => this.Principal + this.Interest;
  }
}