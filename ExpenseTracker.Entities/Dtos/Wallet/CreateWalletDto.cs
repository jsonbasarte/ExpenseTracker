using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Entities.Dtos.Wallet;

public enum WalletType
{
    Cash = 1,
    EWallet = 2,
    Bank = 3,
};


public class CreateWalletDto
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public decimal Balance { get; set; }

    [Required]
    public string WalletName { get; set; } = string.Empty;

    [Required]
    public WalletType WalletType { get; set; }
}
