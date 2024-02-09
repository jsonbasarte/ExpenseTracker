
namespace ExpenseTracker.DataService.Interface.Repo;

public interface IUnitOfWork
{
    ICategoryRepository Category { get; }
    IWalletRepository Wallet { get; }
    Task<bool> SaveAsync();
}
