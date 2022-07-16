using System;
using System.Collections.Generic;
using System.ComponentModel;
using tshreader.Models;
using tshreader.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tshreader.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}