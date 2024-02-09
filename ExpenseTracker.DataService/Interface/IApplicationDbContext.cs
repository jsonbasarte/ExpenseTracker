

using ExpenseTracker.Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.DataService.Interface;

public interface IApplicationDbContext
{
    DbSet<Category> Categories { get; set; }
    DbSet<TransactionDetails> TransactionDetails { get; set; }
    DbSet<Wallet> Wallet { get; set; }
}
