using SearchBarApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Font Awesome 5 Free-Regular-400.otf", Alias = "FontAwesomeRegular")]
[assembly: ExportFont("Font Awesome 5 Free-Solid-900.otf", Alias = "FontAwesomeBold")]
namespace SearchBarApp
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Menu();
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
