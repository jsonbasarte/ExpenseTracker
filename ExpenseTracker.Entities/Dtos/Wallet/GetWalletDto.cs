
namespace ExpenseTracker.Entities.Dtos.Wallet;

public class GetWalletDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public string TypeName { get; set; } = string.Empty;
}
