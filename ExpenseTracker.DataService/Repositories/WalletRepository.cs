
using ExpenseTracker.DataService.Data;
using ExpenseTracker.DataService.Interface.Repo;
using ExpenseTracker.Entities.DbSet;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.DataService.Repositories;

public class WalletRepository : BaseRepostory<Wallet>, IWalletRepository
{
    public WalletRepository(ApplicationDbContext dbContext, ILogger logger) : base(dbContext, logger)
    {
        
    }
}
