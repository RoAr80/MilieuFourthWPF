using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilieuFourthWPF
{
    public class NavigationService : INavigationService
    {
        public BaseViewModel CurrentPage { get; private set; }
        public long UserSessionLocalId { get; set; }
        IViewModelAbstractFactory _viewModelAbstractFactory;
        public NavigationService(IViewModelAbstractFactory viewModelAbstractFactory)
        {
            _viewModelAbstractFactory = viewModelAbstractFactory;
        }

        public void NavigateTo(ApplicationWindowPageEnum appPageEnum)
        {
            var vm = _viewModelAbstractFactory.CreateViewModel(appPageEnum);

            // Property Injection O_o. Как будто должно быть в другом месте
            vm._navigationService = this;
            CurrentPage = vm;
        }

        public void NavigateTo(ApplicationWindowPageEnum appPageEnum, object payload)
        {
            throw new NotImplementedException();
        }
    }


}

