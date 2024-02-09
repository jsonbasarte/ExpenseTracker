

using ExpenseTracker.Entities.DbSet;

namespace ExpenseTracker.DataService.Interface.Repo;

public interface ITransactionDetails : IBaseRepository<TransactionDetails>
{
    Task<IEnumerable<TransactionDetails>> GetCustomerTransaction(int transactionId);
}
