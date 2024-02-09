using ExpenseTracker.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.DataService.Interface.Repo;

public interface IWalletRepository : IBaseRepository<Wallet>
{
}
