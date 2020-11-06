using SearchBarApp.Views;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SearchBarApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuDetail : ContentPage
    {
        public MenuDetail()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProductsPage());
        }
    }
}