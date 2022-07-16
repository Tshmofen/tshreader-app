using tshreader.core.Domain.Models.Book;
using tshreader.core.Domain.Models.Media;
using tshreader.core.Domain.Models.Resource;
using tshreader.core.Domain.Models.Setting;
using tshreader.core.Repository;
using tshreader.services.Book;
using tshreader.services.Media;
using tshreader.services.Resource;
using tshreader.services.Setting;
using tshreader.ViewModels.Common;
using tshreader.ViewModels;

namespace tshreader.Views;

public partial class App
{
    #region Fields

    private static IServiceProvider ServiceProvider { get; set; }

    #endregion

    #region Startup

    public App()
    {
        InitializeComponent();
        InitializeServices();

        MainPage = new AppShell();
    }

    private static void InitializeServices()
    {
        var services = new ServiceCollection();

        // repositories
        services.AddSingleton<IRepository<Book>, EntityRepository<Book>>();
        services.AddSingleton<IRepository<Media>, EntityRepository<Media>>();
        services.AddSingleton<IRepository<Setting>, EntityRepository<Setting>>();
        services.AddSingleton<IRepository<Language>, EntityRepository<Language>>();
        services.AddSingleton<IRepository<TextResource>, EntityRepository<TextResource>>();

        // services
        services.AddSingleton<IBookService, BookService>();
        services.AddSingleton<IMediaService, MediaService>();
        services.AddSingleton<ISettingService, SettingService>();
        services.AddSingleton<ILanguageService, LanguageService>();
        services.AddSingleton<ITextResourceService, TextResourceService>();

        // view models
        services.AddTransient<MainViewModel>();
        services.AddTransient<RecentBooksViewModel>();

        ServiceProvider = services.BuildServiceProvider();
    }

    #endregion

    #region DI methods

    public static TViewModel GetViewModel<TViewModel>() where TViewModel : BaseViewModel
    {
        var viewModel = ServiceProvider.GetService<TViewModel>();

        if (viewModel == null)
        {
            throw new NullReferenceException("View model cannot be found");
        }

        return viewModel;
    }

    #endregion

}