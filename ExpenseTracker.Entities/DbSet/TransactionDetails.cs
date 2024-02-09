
namespace ExpenseTracker.Entities.DbSet;
public enum TransactionType
{
    Credit = 1,
    Expense = 2,
}
public class TransactionDetails : BaseEntity
{
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public int WalletId { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public Category Category { get; set; } = null;
    public Wallet Wallet { get; set; }
    public TransactionType TransactionType { get; set; }
}
