
using ExpenseTracker.DataService.Data;
using ExpenseTracker.DataService.Interface.Repo;
using ExpenseTracker.Entities.DbSet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.DataService.Repositories;

public class TransactionRepository : BaseRepostory<TransactionDetails>, ITransactionDetails
{
    public TransactionRepository(ApplicationDbContext dbContext, ILogger logger) : base(dbContext, logger)
    {
    }

    public override async Task<bool> Add(TransactionDetails request)
    {
        try
        {
            var userWallet = await  _dbContext.Wallet
                .FirstAsync(w => w.UserId == request.UserId && w.Id == request.WalletId);

            if (request.TransactionType == TransactionType.Expense)
            {
                userWallet.Balance = userWallet.Balance - request.Amount;
            }
            else if (request.TransactionType == TransactionType.Credit)
            {
                userWallet.Balance = userWallet.Balance + request.Amount;
            }

            _dbSet.Add(request);

             _dbContext.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Create Transaction function error", typeof(TransactionRepository));
            throw;
        }
    }

    public override async Task<IEnumerable<TransactionDetails>> GetAll()
    {
        try
        {
            return await _dbSet.ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Get All Tranasction error", typeof(TransactionRepository));
            throw;
        }
    }

    public async Task<IEnumerable<TransactionDetails>> GetCustomerTransaction(int customerId)
    {
        try
        {
            return await _dbSet.Where(x => x.UserId == customerId)
                .OrderBy(x => x.DateCreated)
                .ToListAsync();
        }
        catch(Exception e)
        {
            _logger.LogError(e, "{Repo} Get All Customer Transaction error", typeof(TransactionRepository));
            throw;
        }
    }
}
