using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milieu.Models.ClientSide.SideNavigationMenuModel
{
    public class NavigationItem
    {
        public string Title { get; set; }
        public AppPageEnum AppPage { get; set; }
        public string Icon { get; set; }
    }
}
