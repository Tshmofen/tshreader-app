using System;
using tshreader.Services;
using tshreader.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tshreader
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
