using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Entities.Dtos.Wallet;

public class UpdateWalletDto
{
    public int Id { get; set; } 

    [Required]
    public int UserId { get; set; }

    [Required]
    public decimal Balance { get; set; }

    [Required]
    public string WalletName { get; set; } = string.Empty;

    [Required]
    public WalletType WalletType { get; set; }
}
