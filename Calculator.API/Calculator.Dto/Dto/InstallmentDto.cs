// // <copyright file="InstallmentDto.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>27-01-2021</date>
// // <summary>InstallmentDto.cs</summary>

namespace Calculator.Dto.Dto
{
  public class InstallmentDto
  {
    public decimal Capital { get; set; }
    public decimal Interest { get; set; }
    public decimal Installment => this.Capital + this.Interest;
  }
}