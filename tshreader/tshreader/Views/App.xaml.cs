using tshreader.Infrastructure;
using tshreader.ViewModels;

namespace tshreader.Views;

public partial class App
{
    public App()
    {
        InitializeComponent();
        AppInfrastructure.SetupInfrastructure();
        MainPage = new AppShell();
    }

    public static TViewModel GetViewModel<TViewModel>() where TViewModel : BaseViewModel 
        => AppInfrastructure.GetViewModel<TViewModel>();
}