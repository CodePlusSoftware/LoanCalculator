// // <copyright file="CalculatorDbContext.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>28-01-2021</date>
// // <summary>CalculatorDbContext.cs</summary>

using Calculator.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Core
{
  public class CalculatorDbContext : DbContext
  {
    public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options)
      : base(options)
    {
    }

    public DbSet<LoanType> LoanType { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<LoanType>().Property(x => x.Name).IsRequired().HasMaxLength(64);
      modelBuilder.Entity<LoanType>().Property(x => x.Description).IsRequired().HasMaxLength(255);
      modelBuilder.Entity<LoanType>().Property(x => x.InterestRate).IsRequired();

      base.OnModelCreating(modelBuilder);
    }
  }
}