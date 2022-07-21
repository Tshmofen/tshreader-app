using System.Reflection;
using tshreader.core.Domain.Models.Books;
using tshreader.core.Domain.Models.Media;
using tshreader.core.Domain.Models.Resources;
using tshreader.core.Domain.Models.Settings;
using tshreader.core.Repository;
using tshreader.services.Services.Books;
using tshreader.services.Services.Media;
using tshreader.services.Services.Resources;
using tshreader.services.Services.Settings;
using tshreader.ViewModels.Books;
using tshreader.ViewModels;
using tshreader.Views;

namespace tshreader.Infrastructure;

public static class AppInfrastructure
{
    #region Fields

    private static bool _isResolved;
    private static IServiceProvider ServiceProvider { get; set; }

    #endregion

    #region Startup

    public static void SetupInfrastructure()
    {
        if (_isResolved)
        {
            throw new MethodAccessException("Infrastructure is already resolved");
        }

        InitializeServices();

        _isResolved = true;
    }

    private static void InitializeServices()
    {
        var services = new ServiceCollection();

        // mapper
        services.AddAutoMapper(cfg => cfg.AddMaps("tshreader.core", "tshreader.services", "tshreader"));

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

        var viewModelTypes = Assembly
            .GetAssembly(typeof(App))!
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(BaseViewModel)));

        foreach (var viewModelType in viewModelTypes)
        {
            services.AddTransient(viewModelType);
        }

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