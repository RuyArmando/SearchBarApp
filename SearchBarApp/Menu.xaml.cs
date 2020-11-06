using SearchBarApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SearchBarApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
            Detail = new NavigationPage(new MenuDetail());
        }

		private void GoPage1(object sender, System.EventArgs e)
		{
			Detail.Navigation.PushAsync(new ProductsPage());
			IsPresented = false;
			IsGestureEnabled = false;
		}
		private void GoPage2(object sender, System.EventArgs e)
		{
			Detail.Navigation.PushAsync(new CompanySearchPage());
			IsPresented = false;
		}
		private void GoPage3(object sender, System.EventArgs e)
		{
			Detail.Navigation.PushAsync(new ProductsSearchPage());
			IsPresented = false;
		}
	}
}