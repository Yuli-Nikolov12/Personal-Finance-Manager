using Microsoft.EntityFrameworkCore;
using PersonalFinance.Business.Entities;

namespace PersonalFinance.DataAccess.Contexts
{
    public class PersonalFinanceContext : DbContext
    {
        public PersonalFinanceContext(DbContextOptions<PersonalFinanceContext> options) : base(options)
        { }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.TransactionId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Currency)
                .WithMany()
                .HasForeignKey(t => t.CurrencyId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Transactions)
                .WithOne(t => t.Category)
                .HasForeignKey(t => t.CategoryId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Budgets)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<Budget>()
                .HasKey(b => b.BudgetId);

            modelBuilder.Entity<Budget>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Budgets)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<Report>()
                .HasKey(r => r.ReportId);

            modelBuilder.Entity<Report>()
                .HasMany(r => r.Transactions)
                .WithOne() 
                .HasForeignKey(t => t.TransactionId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Currency>()
                .HasKey(c => c.CurrencyId);

            modelBuilder.Entity<Currency>()
                .HasIndex(c => c.CurrencyCode)
                .IsUnique();

            modelBuilder.Entity<Transaction>()
                .HasIndex(t => t.TransactionDate)
                .HasDatabaseName("IX_TransactionDate");
        }
    }
}
