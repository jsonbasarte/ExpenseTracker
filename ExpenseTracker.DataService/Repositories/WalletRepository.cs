
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

    public override async Task<bool> Update(Wallet param)
    {
        try
        {
            var wallet = await _dbSet.FirstOrDefaultAsync(prop => prop.Id == param.Id);

            if (wallet == null)
                return false;

            wallet.Name = param.Name;
            wallet.Balance = param.Balance;
            wallet.Type = param.Type;

            return true;
        }
        catch(Exception e)
        {
            _logger.LogError(e, "{Repo} Update Category error", typeof(CategoryRepository));
            throw;
        }
    }

}
