

using ExpenseTracker.DataService.Data;
using ExpenseTracker.DataService.Interface.Repo;
using ExpenseTracker.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.DataService.Repositories;

public class CategoryRepository : BaseRepostory<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext, ILogger logger) : base(dbContext, logger)
    {
    }

    public override async Task<IEnumerable<Category>> GetAll()
    {
        try
        
        {
            return await _dbSet.ToListAsync();
        }
        catch(Exception e) 
        {
            _logger.LogError(e, "{Repo} Get all Category error", typeof(CategoryRepository));
            throw;
        }
    }

}
