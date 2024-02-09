
namespace ExpenseTracker.DataService.Interface.Repo;

public interface IUnitOfWork
{
    ICategoryRepository Category { get; }
    IWalletRepository Wallet { get; }
    ITransactionDetails Transaction { get; }
    Task<bool> SaveAsync();
}
