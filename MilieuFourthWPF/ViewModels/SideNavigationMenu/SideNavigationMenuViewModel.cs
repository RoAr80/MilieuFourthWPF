﻿using Milieu.ClientModels.ClientSide.SideNavigationMenuModel;
using Milieu.ClientModels.SideNavigationMenuModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;

namespace MilieuFourthWPF
{
    public class SideNavigationMenuViewModel : BaseViewModel
    {
        public class NavigationItem
        {
            public string Title { get; set; }
            public ApplicationWindowControlEnum AppPage { get; set; }
            public string Icon { get; set; }
        }

        // Нужна ли тут модель вообще
        SideNavigationMenuModel _model;
        public SideNavigationMenuViewModel(INavigationService navigationService,  SideNavigationMenuModel model)
        {
            _navigationService = navigationService;
            _model = model;
            _navigationService.PageChanged += _navigationService_PageChanged;
        }
        
        public ObservableCollection<NavigationItem> NavigationList { get; set; } = new ObservableCollection<NavigationItem>
        {
            new NavigationItem() { Title = "Главная", AppPage = ApplicationWindowControlEnum.Home, Icon = App.Current.Resources["FontAwesomeHome"].ToString() },
            new NavigationItem() { Title = "Карточки", AppPage = ApplicationWindowControlEnum.Cards, Icon = App.Current.Resources["FontAwesomeCards"].ToString() },
            new NavigationItem() { Title = "Статистика", AppPage = ApplicationWindowControlEnum.Stats, Icon = App.Current.Resources["FontAwesomeStats"].ToString() },
            new NavigationItem() { Title = "Настройки", AppPage = ApplicationWindowControlEnum.Settings, Icon = App.Current.Resources["FontAwesomeSettings"].ToString() },
            new NavigationItem() { Title = "Магазин", AppPage = ApplicationWindowControlEnum.Store, Icon = App.Current.Resources["FontAwesomeStore"].ToString() },
        };

        //public ObservableCollection<NavigationItem> NavigationList => _model.NavigationList;
        public NavigationItem SelectedNavigationItem { get; set; }

        public Visibility NavMenuVisibility { get; set; }

        public override ApplicationWindowControlEnum ApplicationWindowControlEnumName => ApplicationWindowControlEnum.SideMenuNavigation;

        #region Event Handlers
        private void _navigationService_PageChanged(object sender, ApplicationWindowEventArgs e)
        {
            
            NavMenuVisibility = _navigationService.CurrentPageEnum == ApplicationWindowControlEnum.LoginAndRegistration ? Visibility.Collapsed : Visibility.Visible;

            //SelectedNavigationItem = NavigationList.First(item => item.AppPage == (sender as INavigationService).CurrentPageEnum);
            //SelectedNavigationItem = NavigationList[0];
            SelectedNavigationItem = NavigationList.FirstOrDefault(item => item.AppPage == (sender as INavigationService).CurrentPageEnum);
        }
        #endregion

        //private RelayCommand _addNavItem = null;
        //public RelayCommand AddNavItemCommand => _addNavItem ??
        //    (_addNavItem = new RelayCommand(AddNavItemMethod));

        //private void AddNavItemMethod()
        //{
        //    _model.AddNavItem();
        //}
    }
}
