using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilieuFourthWPF
{
    public interface INavigationService
    {
        void NavigateTo(AppPageEnum appPageEnum);
        void NavigateTo(AppPageEnum appPageEnum, object payload);
    }
}
