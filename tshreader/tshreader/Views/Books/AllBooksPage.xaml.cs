using tshreader.ViewModels.Books;

namespace tshreader.Views.Books;

public partial class AllBooksPage
{
    public AllBooksPage()
    {
        InitializeComponent();
        BindingContext = App.GetViewModel<AllBooksViewModel>();
    }
}