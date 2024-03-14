
using ExpenseTracker.Entities.DbSet;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Entities.Dtos.TransactionDetails;

public class CreateTransactionDto
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public int WalletId { get; set; }
    public string Description { get; set; } = string.Empty;

    [Required]
    public decimal Amount { get; set; }

    public DateTime Date { get; set; }

    [Required]
    public TransactionType TransactionType { get; set; }
}
