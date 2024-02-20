using ExpenseTracker.DataService.Data;
using ExpenseTracker.DataService.Interface.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.DataService.Repositories;

public class BaseRepostory<T> : IBaseRepository<T> where T : class
{
    public readonly ILogger _logger;
    public readonly ApplicationDbContext _dbContext;
    internal DbSet<T> _dbSet;

    public BaseRepostory(
        ApplicationDbContext dbContext,
        ILogger logger)
    {
        _dbContext = dbContext;
        _logger = logger;
        _dbSet = dbContext.Set<T>();
    }

    public virtual async Task<bool> Add(T entity)
    {
       await _dbSet.AddAsync(entity);
        return true;
    }

    public virtual Task<bool> Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task<IEnumerable<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }
}
