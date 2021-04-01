using System.Diagnostics;

namespace MilieuFourthWPF
{
    public class ViewModelAbstractFactory : IViewModelAbstractFactory
    {
        private readonly IViewModelFactory<LoginAndRegViewModel> _loginAndRegViewModelFactory;
        
        // Это вообще здесь нужно?
        private readonly IViewModelFactory<SideNavigationMenuViewModel> _sideNavigationMenuViewModelFactory;
        private readonly IViewModelFactory<HomeViewModel> _homeViewModelFactory;
        public ViewModelAbstractFactory(IViewModelFactory<SideNavigationMenuViewModel> sideNavigationMenuViewModelFactory,
            IViewModelFactory<LoginAndRegViewModel> loginAndRegViewModelFactory,            
            IViewModelFactory<HomeViewModel> homeViewModelFactory)
        {
            _sideNavigationMenuViewModelFactory = sideNavigationMenuViewModelFactory;
            
            _loginAndRegViewModelFactory = loginAndRegViewModelFactory;
            _homeViewModelFactory = homeViewModelFactory;
        }

        public BaseViewModel CreateViewModel(ApplicationWindowControlEnum appPageEnum)
        {
            switch ((ApplicationWindowControlEnum)appPageEnum)
            {
                case ApplicationWindowControlEnum.LoginAndRegistration:                    
                    return _loginAndRegViewModelFactory.CreateViewModel();                
                case ApplicationWindowControlEnum.Home:
                    return _homeViewModelFactory.CreateViewModel();
                default:
                    Debugger.Break();
                    return null;
            }
        }        
    }
}
