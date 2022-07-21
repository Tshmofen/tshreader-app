using tshreader.services.Models.Books;
namespace tshreader.services.Services.Books;

public interface IBookService
{
    Task<int> CountBooksAsync(string name = null, string author = null);
    Task<IList<BookModel>> GetBooksAsync(string name = null, string author = null, int pageIndex = 0, int pageSize = int.MaxValue);
    Task<BookModel> GetBookAsync(int id);
    Task AddBookAsync(BookModel bookModel);
    Task UpdateBookAsync(BookModel bookModel);
    Task DeleteBookAsync(int id);
    Task<IList<BookModel>> GetBooksFromFileSystemAsync(string path);
}
