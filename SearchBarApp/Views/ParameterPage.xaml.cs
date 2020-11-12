using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using System;

namespace SearchBarApp.Views
{
    public partial class ParameterPage : PopupPage
    {
        bool IsBarCodeSelect;
        bool IsDescriptionSelect;
        bool IsBrandSelect;

        public ParameterPage()
        {
            InitializeComponent();
        }

        private void IsBarCode_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            IsBarCodeSelect = e.Value;
        }

        private void IsDescription_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            IsDescriptionSelect = e.Value;
        }

        private void IsBrand_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            IsBrandSelect = e.Value;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<App, string>(App.Current as App, "OpenPage", $"Description: {IsDescriptionSelect} BarCode: {IsBarCodeSelect} Brand: {IsBrandSelect}");
            await Navigation.PopPopupAsync();
        }
    }
}