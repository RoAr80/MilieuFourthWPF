using Milieu.ClientModels.ClientSide.SideNavigationMenuModel;
using Milieu.ClientModels.SideNavigationMenuModel;

namespace MilieuFourthWPF
{
    public class SideNavigationMenuViewModel
    {
        SideNavigationMenuModel _model = new SideNavigationMenuModel();
        //public ObservableCollection<NavigationItem> NavigationList => _model.NavigationList;
        public NavigationItem SelectedNavigationItem { get; set; }

        //private RelayCommand _addNavItem = null;
        //public RelayCommand AddNavItemCommand => _addNavItem ??
        //    (_addNavItem = new RelayCommand(AddNavItemMethod));

        //private void AddNavItemMethod()
        //{
        //    _model.AddNavItem();
        //}
    }
}
