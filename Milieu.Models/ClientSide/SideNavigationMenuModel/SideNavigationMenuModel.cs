using System.Collections.ObjectModel;

namespace Milieu.Models.ClientSide.SideNavigationMenuModel
{
    public enum AppPageEnum
    {
        Home,
        Cards,
        Stats,
        Settings,
        Store
    }    

    public class SideNavigationMenuModel
    {
        
        public ObservableCollection<NavigationItem> NavigationList { get; set; } = new ObservableCollection<NavigationItem>
        {
            new NavigationItem() { Title = "Главная", AppPage = AppPageEnum.Home, Icon = "&#xf015;" },
            new NavigationItem() { Title = "Карточки", AppPage = AppPageEnum.Cards, Icon = "H" },
            new NavigationItem() { Title = "Статистика", AppPage = AppPageEnum.Stats, Icon = "H" },
            new NavigationItem() { Title = "Настройки", AppPage = AppPageEnum.Settings, Icon = "H" },
            new NavigationItem() { Title = "Магазин", AppPage = AppPageEnum.Store, Icon = "H" },            
        };

        public void AddNavItem()
        {
            NavigationList.Add(new NavigationItem { Title = "Магазин", AppPage = AppPageEnum.Store, Icon = "H" });
        }
    }
}
