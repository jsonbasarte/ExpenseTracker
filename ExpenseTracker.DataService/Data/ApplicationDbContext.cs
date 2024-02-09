
using ExpenseTracker.DataService.Interface;
using ExpenseTracker.DataService.Models;
using ExpenseTracker.Entities.DbSet;
using ExpenseTracker.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.DataService.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<Category> Categories { get; set; }
    public DbSet<TransactionDetails> TransactionDetails { get; set; }
    public DbSet<Wallet> Wallet { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Balance).HasColumnType("decimal(18,2)");
            entity.HasOne<ApplicationUser>().WithMany().HasForeignKey(d => d.UserId);
            entity.Property(u => u.Name).HasMaxLength(200);
            entity.Property(u => u.Type).HasMaxLength(7);
        });

        modelBuilder.Entity<TransactionDetails>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Date).IsRequired();
            entity.HasOne<ApplicationUser>().WithMany().HasForeignKey(e => e.UserId);
            entity.HasOne(e => e.Category).WithMany().HasForeignKey(e => e.CategoryId);
            entity.HasOne(e => e.Wallet).WithMany().HasForeignKey(e => e.WalletId).OnDelete(DeleteBehavior.Restrict);
            entity.Property(e => e.TransactionType).IsRequired();
        });
    }
}
