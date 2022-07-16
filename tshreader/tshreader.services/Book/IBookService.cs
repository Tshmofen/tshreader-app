using eBook = tshreader.core.Domain.Models.Book.Book;
namespace tshreader.services.Book;

public interface IBookService
{
    Task<int> CountBooksAsync(string name = null, string author = null);
    Task<IList<eBook>> GetBooksAsync(string name = null, string author = null, int pageIndex = 0, int pageSize = int.MaxValue);
    Task<eBook> GetBookAsync(int id);
    Task AddBookAsync(eBook book);
    Task UpdateBookAsync(eBook book);
    Task DeleteBookAsync(int id);
}
