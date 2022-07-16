using JetBrains.Annotations;
using tshreader.ViewModels.Common;

namespace tshreader.Views.Books;

public partial class AllBooksPage
{
    private int _count;

    public AllBooksPage()
    {
        InitializeComponent();
        BindingContext = App.GetViewModel<RecentBooksViewModel>();
    }

    [UsedImplicitly]
    private void OnCounterClicked(object sender, EventArgs e)
    {
        _count++;
        CounterBtn.Text = _count == 1 ? $"Clicked {_count} time" : $"Clicked {_count} times";
        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}