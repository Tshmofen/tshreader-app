using SQLite;
using tshreader.core.Domain.Models;

namespace tshreader.core.Repository;

public interface IRepository<TEntity> where TEntity : BaseEntity, new()
{
    Task<int> CountAsync(Func<AsyncTableQuery<TEntity>, AsyncTableQuery<TEntity>>? applySearchTerms = null);
    Task<IList<TEntity>> GetAllAsync(Func<AsyncTableQuery<TEntity>, AsyncTableQuery<TEntity>>? applySearchTerms = null, int pageIndex = 0, int pageSize = int.MaxValue);
    Task<TEntity> GetAsync(int id);
    Task<TEntity> GetAsync(Func<AsyncTableQuery<TEntity>, AsyncTableQuery<TEntity>> applySearchTerms);
    Task<int> AddAsync(TEntity item);
    Task UpdateAsync(TEntity item);
    Task DeleteAsync(int id);
    Task DeleteAsync(Func<AsyncTableQuery<TEntity>, AsyncTableQuery<TEntity>> applyDeleteTerms);
}
