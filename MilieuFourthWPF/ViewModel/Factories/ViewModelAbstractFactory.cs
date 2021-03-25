using System.Diagnostics;

namespace MilieuFourthWPF
{
    public class ViewModelAbstractFactory : IViewModelAbstractFactory
    {
        private readonly IViewModelFactory<LoginAndRegViewModel> _loginAndRegViewModelFactory;
        private readonly IViewModelFactory<SideNavigationMenuViewModel> _sideNavigationMenuViewModelFactory;
        public ViewModelAbstractFactory(IViewModelFactory<SideNavigationMenuViewModel> sideNavigationMenuViewModelFactory,
            IViewModelFactory<LoginAndRegViewModel> loginAndRegViewModelFactory)
        {
            _sideNavigationMenuViewModelFactory = sideNavigationMenuViewModelFactory;
            _loginAndRegViewModelFactory = loginAndRegViewModelFactory;
        }

        public BaseViewModel CreateViewModel(ApplicationWindowPageEnum appPageEnum)
        {
            switch ((ApplicationWindowPageEnum)appPageEnum)
            {
                case ApplicationWindowPageEnum.LoginAndRegPage:
                    return _loginAndRegViewModelFactory.CreateViewModel();
                //case ApplicationWindowPageEnum.Application:
                //    return _sideNavigationMenuViewModelFactory.CreateViewModel();                
                default:
                    Debugger.Break();
                    return null;
            }
        }        
    }
}
