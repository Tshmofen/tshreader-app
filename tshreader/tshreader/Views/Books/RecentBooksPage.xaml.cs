using tshreader.ViewModels.Books;

namespace tshreader.Views.Books;

public partial class RecentBooksPage
{
    public RecentBooksPage()
    {
        InitializeComponent();
        BindingContext = App.GetViewModel<RecentBooksViewModel>();
    }
}