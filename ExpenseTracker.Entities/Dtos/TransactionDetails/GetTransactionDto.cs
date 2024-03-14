

namespace ExpenseTracker.Entities.Dtos.TransactionDetails;

public class GetTransactionDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; } 
    public string Description { get; set; } = string.Empty;
    public string DateCreated { get; set; } = string.Empty;
    public string WalletName { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public string TransactionType { get; set; } = string.Empty;
}
