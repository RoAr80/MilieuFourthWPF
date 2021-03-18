using Milieu.Models.ClientSide.SideNavigationMenuModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilieuFourthWPF
{
    public class SideNavigationMenuViewModel
    {
        SideNavigationMenuModel _model = new SideNavigationMenuModel();
        public ObservableCollection<NavigationItem> NavigationList => _model.NavigationList;
        public NavigationItem SelectedNavigationItem { get; set; }

        private RelayCommand _addNavItem = null;
        public RelayCommand AddNavItemCommand => _addNavItem ??
            (_addNavItem = new RelayCommand(AddNavItemMethod));

        private void AddNavItemMethod()
        {
            _model.AddNavItem();
        }
    }
}
