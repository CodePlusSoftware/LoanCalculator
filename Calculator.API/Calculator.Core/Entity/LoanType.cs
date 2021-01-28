// // <copyright file="LoanType.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>28-01-2021</date>
// // <summary>LoanType.cs</summary>

using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Core.Entity
{
  [Table("LoanTypes")]
  public class LoanType
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    
    public float InterestRate { get; set; }
  }
}