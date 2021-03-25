using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilieuFourthWPF
{
    public interface INavigationService
    {
        BaseViewModel CurrentPage { get; }
        long UserSessionLocalId { get; set; }
        void NavigateTo(ApplicationWindowPageEnum appPageEnum);
        void NavigateTo(ApplicationWindowPageEnum appPageEnum, object payload);
    }
}
