using Milieu.ClientModels.Database.Repos;

namespace MilieuFourthWPF
{
    public class NavigationAndAppViewModelFactory : IViewModelFactory<NavigationAndAppViewModel>
    {
        private IClientRepo _clientRepo;
        private ApplicationWindowViewModel _appVM;

        public NavigationAndAppViewModelFactory(IClientRepo clientRepo, ApplicationWindowViewModel appVM)
        {
            _clientRepo = clientRepo;
            _appVM = appVM;
        }

        public NavigationAndAppViewModel CreateViewModel()
        {
            return new NavigationAndAppViewModel(_clientRepo, _appVM);
        }
    }
}
