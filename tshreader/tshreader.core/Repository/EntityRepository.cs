using SQLite;
using tshreader.core.Domain.Defaults;
using tshreader.core.Domain.Models;

namespace tshreader.core.Repository;

public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
{
    #region Ctor

    private readonly SQLiteAsyncConnection _database;

    public EntityRepository()
    {
        _database = DatabaseDefaults.Connection;
        _database.CreateTableAsync<TEntity>(DatabaseDefaults.TableFlags).Wait();
    }

    #endregion

    public async Task<int> CountAsync(Func<AsyncTableQuery<TEntity>, AsyncTableQuery<TEntity>>? applySearchTerms = null)
    {
        var table = _database.Table<TEntity>();

        if (applySearchTerms != null)
        {
            table = applySearchTerms(table);
        }

        return await table.CountAsync();
    }

    public async Task<IList<TEntity>> GetAllAsync(Func<AsyncTableQuery<TEntity>, AsyncTableQuery<TEntity>>? applySearchTerms = null,
        int pageIndex = 0, int pageSize = int.MaxValue)
    {
        var table = _database.Table<TEntity>();

        if (applySearchTerms != null)
        {
            table = applySearchTerms(table);
        }

        return await table
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<TEntity> GetAsync(int id)
    {
        return await _database.Table<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<TEntity> GetAsync(Func<AsyncTableQuery<TEntity>, AsyncTableQuery<TEntity>> applySearchTerms)
    {
        var query = applySearchTerms(_database.Table<TEntity>());
        return await query.FirstOrDefaultAsync();
    }

    public async Task<int> AddAsync(TEntity item)
    {
        await _database.InsertAsync(item);
        return await _database.GetInsertedRowIdAsync();
    }

    public async Task UpdateAsync(TEntity item)
    {
        await _database.UpdateAsync(item);
    }

    public async Task DeleteAsync(int id)
    {
        await _database.Table<TEntity>().DeleteAsync(e => e.Id == id);
    }

    public async Task DeleteAsync(Func<AsyncTableQuery<TEntity>, AsyncTableQuery<TEntity>> applyDeleteTerms)
    {
        var table = _database.Table<TEntity>();
        table = applyDeleteTerms(table);
        await table.DeleteAsync();
    }
}
