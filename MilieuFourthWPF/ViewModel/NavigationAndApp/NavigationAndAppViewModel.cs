using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MilieuFourthWPF.Database.Repos;

namespace MilieuFourthWPF
{
    public class NavigationAndAppViewModel : BaseViewModel
    {
        
        public class NavigationItem
        {
            public string Title { get; set; }
            public AppPageEnum AppPage { get; set; }
            public string Icon { get; set; }
        }
        
        public ObservableCollection<NavigationItem> NavigationList { get; set; } = new ObservableCollection<NavigationItem>
        {
            new NavigationItem() { Title = "Главная", AppPage = AppPageEnum.Home, Icon = App.Current.Resources["FontAwesomeHome"].ToString() },
            new NavigationItem() { Title = "Карточки", AppPage = AppPageEnum.Cards, Icon = App.Current.Resources["FontAwesomeCards"].ToString() },
            new NavigationItem() { Title = "Статистика", AppPage = AppPageEnum.Stats, Icon = App.Current.Resources["FontAwesomeStats"].ToString() },
            new NavigationItem() { Title = "Настройки", AppPage = AppPageEnum.Settings, Icon = App.Current.Resources["FontAwesomeSettings"].ToString() },
            new NavigationItem() { Title = "Магазин", AppPage = AppPageEnum.Store, Icon = App.Current.Resources["FontAwesomeStore"].ToString() },
        };
        public ObservableCollection<NavigationItem> AlmostSame { get; set; } = new ObservableCollection<NavigationItem>
        {
            new NavigationItem() { Title = "Главная", AppPage = AppPageEnum.Home, Icon = App.Current.Resources["FontAwesomeHome"].ToString() },
            new NavigationItem() { Title = "Карточки", AppPage = AppPageEnum.Cards, Icon = App.Current.Resources["FontAwesomeCards"].ToString() },
            new NavigationItem() { Title = "Статистика", AppPage = AppPageEnum.Stats, Icon = App.Current.Resources["FontAwesomeStats"].ToString() },
            new NavigationItem() { Title = "Настройки", AppPage = AppPageEnum.Settings, Icon = App.Current.Resources["FontAwesomeSettings"].ToString() },
            new NavigationItem() { Title = "Магазин", AppPage = AppPageEnum.Store, Icon = App.Current.Resources["FontAwesomeStore"].ToString() },
        };
        public NavigationItem SelectedNavigationItem { get; set; }

        public AppPageEnum CurrentAppPage 
        {
            get {
                if (SelectedNavigationItem == null)
                    return AppPageEnum.Home;
                else
                    return SelectedNavigationItem.AppPage;
            } 
            set { CurrentAppPage = value; } 
        }

        public string UserName { get; set; } = "UnknownLongStoryShort";

        #region Constructor

        public NavigationAndAppViewModel()
        {
            SelectedNavigationItem = NavigationList[0];

            IClientRepo clientRepo = DI.ServiceProvider.GetService<IClientRepo>();
            ApplicationWindowViewModel appVM = DI.ServiceProvider.GetService<ApplicationWindowViewModel>();

            UserName = appVM.UserSessionLocalId != default(long) ? clientRepo.GetEmail(appVM.UserSessionLocalId) : "UnknownLongStoryShort";
        }
        #endregion

        #region Commands

        private RelayCommand _doSmth = null;
        public RelayCommand doSmth => _doSmth ??
            (_doSmth = new RelayCommand(DoSmth));

        private void DoSmth()
        {
            var mwvm = DI.ServiceProvider.GetService<ApplicationWindowViewModel>();
            mwvm.CurrentPage = ApplicationWindowPageEnum.LoginAndRegPage;
        }

        #endregion        

    }
}
