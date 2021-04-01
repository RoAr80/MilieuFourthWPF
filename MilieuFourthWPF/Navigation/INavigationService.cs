using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilieuFourthWPF
{
    public interface INavigationService : INotifyPropertyChanged
    {
        BaseViewModel CurrentPage { get; }
        ApplicationWindowControlEnum CurrentPageEnum { get; set; }
        long UserSessionLocalId { get; set; }
        void NavigateTo(ApplicationWindowControlEnum appPageEnum);
        void NavigateTo(ApplicationWindowControlEnum appPageEnum, object payload);

        event EventHandler<ApplicationWindowEventArgs> PageChanged;
    }
}
