using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilieuFourthWPF
{
    /// <summary>
    /// The design-time data for a <see cref="SideNavigationMenuViewModel"/>
    /// </summary>
    public class SideNavigationMenuDesignModel : SideNavigationMenuViewModel
    {
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SideNavigationMenuDesignModel Instance => new SideNavigationMenuDesignModel();
        public SideNavigationMenuDesignModel() : base(null, null) { }
    }
}
