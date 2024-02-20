

using ExpenseTracker.DataService.Data;
using ExpenseTracker.DataService.Interface.Repo;
using ExpenseTracker.Entities.DbSet;
using ExpenseTracker.Entities.Dtos.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.DataService.Repositories;

public class CategoryRepository : BaseRepostory<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext, ILogger logger) : base(dbContext, logger)
    {
    }

    public async Task<IEnumerable<Category>> GetAll()
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

    public override async Task<bool> Update(Category param)
    {
        try
        {
            var category = await _dbSet.FirstOrDefaultAsync(c => c.Id == param.Id);

            if (category == null)
                return false;

            category.Name = param.Name;

            return true;
        }
        catch(Exception e)
        {
            _logger.LogError(e, "{Repo} Update Category error", typeof(CategoryRepository));
            throw;
        }
    }

}
