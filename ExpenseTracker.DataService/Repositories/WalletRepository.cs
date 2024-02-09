
using ExpenseTracker.DataService.Data;
using ExpenseTracker.DataService.Interface.Repo;
using ExpenseTracker.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.DataService.Repositories;

public class WalletRepository : BaseRepostory<Wallet>, IWalletRepository
{
    public WalletRepository(ApplicationDbContext dbContext, ILogger logger) : base(dbContext, logger)
    {
        
    }

    public override async Task<IEnumerable<Wallet>> GetAll()
    {
        try
        {
            return await _dbSet.ToListAsync();
        }
         catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Get All function error", typeof(WalletRepository));
            throw;
        }
    }
}
