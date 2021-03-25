using Milieu.ClientModels.ClientSide.SideNavigationMenuModel;
using Milieu.ClientModels.SideNavigationMenuModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace MilieuFourthWPF
{
    public class SideNavigationMenuViewModel : BaseViewModel
    {
        public class NavigationItem
        {
            public string Title { get; set; }
            public ApplicationWindowPageEnum AppPage { get; set; }
            public string Icon { get; set; }
        }

        // Нужна ли тут модель вообще
        SideNavigationMenuModel _model;
        public SideNavigationMenuViewModel(INavigationService navigationService,  SideNavigationMenuModel model)
        {
            _navigationService = navigationService;
            _model = model;
            
        }

        public ObservableCollection<NavigationItem> NavigationList { get; set; } = new ObservableCollection<NavigationItem>
        {
            new NavigationItem() { Title = "Главная", AppPage = ApplicationWindowPageEnum.Home, Icon = App.Current.Resources["FontAwesomeHome"].ToString() },
            new NavigationItem() { Title = "Карточки", AppPage = ApplicationWindowPageEnum.Cards, Icon = App.Current.Resources["FontAwesomeCards"].ToString() },
            new NavigationItem() { Title = "Статистика", AppPage = ApplicationWindowPageEnum.Stats, Icon = App.Current.Resources["FontAwesomeStats"].ToString() },
            new NavigationItem() { Title = "Настройки", AppPage = ApplicationWindowPageEnum.Settings, Icon = App.Current.Resources["FontAwesomeSettings"].ToString() },
            new NavigationItem() { Title = "Магазин", AppPage = ApplicationWindowPageEnum.Store, Icon = App.Current.Resources["FontAwesomeStore"].ToString() },
        };

        //public ObservableCollection<NavigationItem> NavigationList => _model.NavigationList;
        public NavigationItem SelectedNavigationItem { get; set; }

        public Visibility NavMenuVisibility 
        { 
            get => _navigationService.CurrentPage.GetType() != typeof(LoginAndRegViewModel) ? Visibility.Collapsed : Visibility.Visible ;              
        }

        //private RelayCommand _addNavItem = null;
        //public RelayCommand AddNavItemCommand => _addNavItem ??
        //    (_addNavItem = new RelayCommand(AddNavItemMethod));

        //private void AddNavItemMethod()
        //{
        //    _model.AddNavItem();
        //}
    }
}
