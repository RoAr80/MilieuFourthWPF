using System.Diagnostics;

namespace MilieuFourthWPF
{
    public class ViewModelAbstractFactory : IViewModelAbstractFactory
    {
        private readonly IViewModelFactory<NavigationAndAppViewModel> _navigationAndAppViewModelFactory;
        private readonly IViewModelFactory<LoginAndRegViewModel> _loginAndRegViewModelFactory;
        public ViewModelAbstractFactory(IViewModelFactory<NavigationAndAppViewModel> navigationAndAppViewModelFactory,
            IViewModelFactory<LoginAndRegViewModel> loginAndRegViewModelFactory)
        {
            _navigationAndAppViewModelFactory = navigationAndAppViewModelFactory;
            _loginAndRegViewModelFactory = loginAndRegViewModelFactory;
        }

        public BaseViewModel CreateViewModel(ApplicationWindowPageEnum appPageEnum)
        {
            switch ((ApplicationWindowPageEnum)appPageEnum)
            {
                case ApplicationWindowPageEnum.Application:
                    return _navigationAndAppViewModelFactory.CreateViewModel();
                case ApplicationWindowPageEnum.LoginAndRegPage:
                    return _loginAndRegViewModelFactory.CreateViewModel();
                default:
                    Debugger.Break();
                    return null;
            }
        }
    }
}
