using System.Collections.Concurrent;
using tshreader.services.Models.Books;
using tshreader.services.Services.Books;

namespace tshreader.ViewModels.Books;

public class AllBooksViewModel : BaseViewModel
{
    private readonly IBookService _bookService;

    public ObservableConcurrentCollection<BookModel> BooksCollection { get; }

    public AllBooksViewModel(IBookService bookService)
    {
        _bookService = bookService;

        Title = "All Books";
        BooksCollection = new ObservableConcurrentCollection<BookModel>();
        Task.Run(LoadBooks);
    }

    private async void LoadBooks()
    {
        await _bookService.AddBookAsync(new BookModel
        {
            Name = "Some Name",
            Author = "Some Author"
        });

        Thread.Sleep(2000);

        var books = await _bookService.GetBooksAsync();
        BooksCollection.AddFromEnumerable(books);
    }
}
