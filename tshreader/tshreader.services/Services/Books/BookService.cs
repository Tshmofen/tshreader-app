using AutoMapper;
using FB2Library;
using SQLite;
using System.Diagnostics;
using System.Xml;
using Microsoft.Maui.Controls;
using tshreader.core.Domain.Models.Books;
using tshreader.core.Repository;
using tshreader.services.Models.Books;

namespace tshreader.services.Services.Books;

public class BookService : IBookService
{
    #region Ctor

    private readonly IRepository<Book> _repository;
    private readonly IMapper _mapper;

    public BookService(IRepository<Book> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    #endregion

    #region Util

    private static AsyncTableQuery<Book> ApplySearchTerms(AsyncTableQuery<Book> table, string name, string author)
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

    public async Task<int> CountBooksAsync(string name = null, string author = null)
    {
        return await _repository.CountAsync((table) => ApplySearchTerms(table, name, author));
    }

    public async Task<IList<BookModel>> GetBooksAsync(string name = null, string author = null, int pageIndex = 0, int pageSize = int.MaxValue)
    {
        var books = await _repository.GetAllAsync((table) => ApplySearchTerms(table, name, author), pageIndex, pageSize);
        return books
                .Select(b => _mapper.Map<Book, BookModel>(b))
                .ToList();
    }

    public async Task<BookModel> GetBookAsync(int id)
    {
        var book = await _repository.GetAsync(id);
        return _mapper.Map<Book, BookModel>(book);
    }

    public async Task AddBookAsync(BookModel bookModel)
    {
        var book = _mapper.Map<BookModel, Book>(bookModel);
        await _repository.AddAsync(book);
    }

    public async Task UpdateBookAsync(BookModel bookModel)
    {
        var book = _mapper.Map<BookModel, Book>(bookModel);
        await _repository.UpdateAsync(book);
    }

    public async Task DeleteBookAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IList<BookModel>> GetBooksFromFileSystemAsync(string path)
    {
        var bookModels = new List<BookModel>();

        if (!Directory.Exists(path))
        {
            return bookModels;
        }

        var files = Directory.GetFiles(path, "*.fb2");
        var reader = new FB2Reader();

        foreach (var filePath in files)
        {
            var readerSettings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Ignore
            };
            var loadSettings = new XmlLoadSettings(readerSettings);

            try
            {
                var stream = File.OpenRead(filePath);
                var fb2File = await reader.ReadAsync(stream, loadSettings);
                var author = fb2File.TitleInfo?.BookAuthors?.FirstOrDefault();

                var bookModel = new BookModel
                {
                    Name = fb2File.TitleInfo?.BookTitle?.Text ?? filePath
                };

                if (author != null)
                {
                    bookModel.Author = author.FirstName + " " + author.MiddleName + " " + author.LastName;
                }

                var coverInfo = fb2File.TitleInfo?.Cover?.CoverpageImages?.FirstOrDefault();
                if (coverInfo != null)
                {
                    var key = coverInfo.HRef.Replace("#", string.Empty);
                    var imageInfo = fb2File.Images
                        .FirstOrDefault(i => i.Key == key);
                    var imageBinary = imageInfo.Value.BinaryData;

                    if (imageBinary != null)
                    {
                        bookModel.Image = ImageSource.FromStream(() => new MemoryStream(imageBinary));
                    }
                }

                bookModels.Add(bookModel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading file : {ex.Message}");
            }
        }

        return bookModels;
    }
}
