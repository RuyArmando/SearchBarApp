using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using System;

namespace SearchBarApp.Views
{
    public partial class SortPage : PopupPage
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