using tshreader.ViewModels.Common;

namespace tshreader.Views.Common;

public partial class SettingsPage
{
    public SettingsPage()
    {
        InitializeComponent();
        BindingContext = App.GetViewModel<SettingsViewModel>();
    }
}