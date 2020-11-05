using SearchBarApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SearchBarApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage();
            var navigationPage = new Xamarin.Forms.NavigationPage(new ProductsPage());
            MainPage = navigationPage;
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
