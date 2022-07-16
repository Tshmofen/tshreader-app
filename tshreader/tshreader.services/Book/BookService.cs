using eBook = tshreader.core.Domain.Models.Book.Book;
using SQLite;
using tshreader.core.Repository;

namespace tshreader.services.Book;

internal class BookService : IBookService
{
    #region Ctor

    private readonly IRepository<eBook> _repository;

    public BookService(IRepository<eBook> repository)
    {
        _repository = repository;
    }

    #endregion

    #region Util

    private static AsyncTableQuery<eBook> ApplySearchTerms(AsyncTableQuery<eBook> table, string? name, string? author)
    {
        if (!string.IsNullOrEmpty(name))
        {
            table = table.Where(p => p.Name!.ToLower().StartsWith(name.ToLower()));
        }

        if (!string.IsNullOrEmpty(author))
        {
            table = table.Where(p => p.Author!.ToLower().StartsWith(author.ToLower()));
        }

        return table;
    }

    #endregion

    public async Task<int> CountBooksAsync(string? name = null, string? author = null)
    {
        return await _repository.CountAsync((table) => ApplySearchTerms(table, name, author));
    }

    public async Task<IList<eBook>> GetBooksAsync(string? name = null, string? author = null, int pageIndex = 0, int pageSize = int.MaxValue)
    {
        return await _repository.GetAllAsync((table) => ApplySearchTerms(table, name, author), pageIndex, pageSize);
    }

    public async Task<eBook> GetBookAsync(int id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task AddBookAsync(eBook book)
    {
        await _repository.AddAsync(book);
    }

    public async Task UpdateBookAsync(eBook book)
    {
        await _repository.UpdateAsync(book);
    }

    public async Task DeleteBookAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

}
