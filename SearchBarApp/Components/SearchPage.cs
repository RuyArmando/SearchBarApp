using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace SearchBarApp.Components
{
    public class SearchPage : ContentPage, ISearchPage
    {
        public static readonly BindableProperty SearchPlaceholderProperty = BindableProperty.Create(nameof(PlaceHolder), typeof(string), typeof(ISearchPage), string.Empty, BindingMode.OneWay);

        public event EventHandler<string> OnSearchText;


        public delegate void PlaceHolderChangedDelegate(string parameter);
        public PlaceHolderChangedDelegate OnPlaceHolderChanged;

        public SearchPage()
        {
            Suggestions = new string[] { };
        }

        public string PlaceHolder
        {
            get => (string)this.GetValue(SearchPlaceholderProperty);
            set => this.SetValue(SearchPlaceholderProperty, value);
        }

        public string[] Suggestions { get; set; }

        public void SearchTextEvent(string text)
        {
            OnSearchText?.Invoke(this, text);
        }
    }
}
