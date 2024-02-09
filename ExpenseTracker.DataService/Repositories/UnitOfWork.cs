
using ExpenseTracker.DataService.Data;
using ExpenseTracker.DataService.Interface.Repo;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.DataService.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public ICategoryRepository Category { get; }

    public IWalletRepository Wallet { get; }

    public ITransactionDetails Transaction { get; }

    public UnitOfWork(ApplicationDbContext dbContext, ILoggerFactory loggerFactory)
    {
        _dbContext = dbContext;

        var logger = loggerFactory.CreateLogger("logs");

        Category = new CategoryRepository(dbContext, logger);

        Wallet = new WalletRepository(dbContext, logger);

        Transaction = new TransactionRepository(dbContext, logger);
    }

    public async Task<bool> SaveAsync()
    {
        return await _dbContext.SaveChangesAsync() > 0;
    }
}
