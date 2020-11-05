using Rg.Plugins.Popup.Extensions;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SearchBarApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SortPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        bool IsAscSelect;
        bool IsDescSelect;

        public SortPage()
        {
            InitializeComponent();
        }

        private void IsASC_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            IsAscSelect = e.Value;
        }

        private void IsDESC_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            IsDescSelect = e.Value;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<App, string>(App.Current as App, "OpenPage", "ASC: " + IsAscSelect.ToString() + "  DESC: " + IsDescSelect.ToString());
            await Navigation.PopPopupAsync();
        }
    }
}