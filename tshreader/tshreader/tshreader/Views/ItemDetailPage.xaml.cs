using System.ComponentModel;
using tshreader.ViewModels;
using Xamarin.Forms;

namespace tshreader.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}