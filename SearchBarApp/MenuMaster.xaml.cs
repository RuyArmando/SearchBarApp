using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SearchBarApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuMaster : ContentPage
    {
        public ListView ListView;

        public MenuMaster()
        {
            InitializeComponent();

            BindingContext = new MenuMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MenuMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MenuMasterMenuItem> MenuItems { get; set; }

            public MenuMasterViewModel()
            {
                MenuItems = new ObservableCollection<MenuMasterMenuItem>(new[]
                {
                    new MenuMasterMenuItem { Id = 0, Title = "Page 1" },
                    new MenuMasterMenuItem { Id = 1, Title = "Page 2" },
                    new MenuMasterMenuItem { Id = 2, Title = "Page 3" },
                    new MenuMasterMenuItem { Id = 3, Title = "Page 4" },
                    new MenuMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}