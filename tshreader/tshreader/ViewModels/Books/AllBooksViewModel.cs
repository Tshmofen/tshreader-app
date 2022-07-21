using System.Collections.Concurrent;
using tshreader.core.Domain.Defaults;
using tshreader.services.Models.Books;
using tshreader.services.Services.Books;
using tshreader.services.Services.Settings;

namespace tshreader.ViewModels.Books;

public class AllBooksViewModel : BaseViewModel
{
    private readonly IBookService _bookService;
    private readonly ISettingService _settingService;

    public ObservableConcurrentCollection<BookModel> BooksCollection { get; }

    public AllBooksViewModel(IBookService bookService, ISettingService settingService)
    {
        _bookService = bookService;
        _settingService = settingService;

        Title = "All Books";
        BooksCollection = new ObservableConcurrentCollection<BookModel>();
        Task.Run(LoadBooks);
    }

    private async void LoadBooks()
    {
        var folder = await _settingService.GetSettingAsync(SettingsDefaults.CurrentBooksFolderSetting);
        var books = await _bookService.GetBooksFromFileSystemAsync(folder ?? string.Empty);
        BooksCollection.AddFromEnumerable(books);
    }
}
