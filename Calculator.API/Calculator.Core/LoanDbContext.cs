using Calculator.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Core
{
  public class LoanDbContext : DbContext
  {
    public LoanDbContext(DbContextOptions<LoanDbContext> options)
      : base(options)
    {
    }

    public DbSet<LoanTypeEntity> LoanType { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<LoanTypeEntity>().Property(x => x.Name).IsRequired().HasMaxLength(64);
      modelBuilder.Entity<LoanTypeEntity>().Property(x => x.Description).IsRequired().HasMaxLength(255);
      modelBuilder.Entity<LoanTypeEntity>().Property(x => x.InterestRate).IsRequired();

      base.OnModelCreating(modelBuilder);
    }
  }
}