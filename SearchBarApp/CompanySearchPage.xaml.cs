using System;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SearchBarApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanySearchPage : ContentPage
    {
        ObservableCollection<string> data = new ObservableCollection<string>();

        public CompanySearchPage()
        {
            InitializeComponent();
            ListOfStore();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((MasterDetailPage)App.Current.MainPage).IsGestureEnabled = true;
        }

        protected override void OnAppearing()
        {
            base.OnDisappearing();
            ((MasterDetailPage)App.Current.MainPage).IsGestureEnabled = false;
        }

        public void ListOfStore()
        {
            try
            {
                data.Add("EMPRESA DEMONSTRACAO CEREAIS");
                data.Add("OPTEC TECNOLOGIA LTDA ");
                data.Add("ASSOC. DE PAIS E AMIGOS DOS EXCEPCIONAIS DE CORONEL VIVIDA");
                data.Add("HUNES");
                data.Add("TECNOLOGIA");
                data.Add("OPTEC");
                data.Add("DEMONSTRACAO");
                data.Add("CEREAIS");
                data.Add("EXCEPCIONAIS");
                data.Add("ASSOC");
                data.Add("EMPRESA");
                data.Add("VIVIDA");
                data.Add("CORONEL");
            }
            catch (Exception ex)
            {
                DisplayAlert("", "" + ex, "Ok");
            }
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            countryListView.IsVisible = true;
            countryListView.BeginRefresh();

            try
            {
                var dataEmpty = data.Where(i => i.ToLower().Contains(e.NewTextValue.ToLower()));

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    countryListView.IsVisible = false;
                else if (dataEmpty.Max().Length == 0)
                    countryListView.IsVisible = false;
                else
                    countryListView.ItemsSource = data.Where(i => i.ToLower().Contains(e.NewTextValue.ToLower()));
            }
            catch (Exception)
            {
                countryListView.IsVisible = false;

            }

            countryListView.EndRefresh();
        }

        private void ListView_OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
            //EmployeeListView.IsVisible = false;  

            var listsd = e.Item as string;
            searchBar.Text = listsd;
            countryListView.IsVisible = false;

            ((ListView)sender).SelectedItem = null;
        }
    }
}