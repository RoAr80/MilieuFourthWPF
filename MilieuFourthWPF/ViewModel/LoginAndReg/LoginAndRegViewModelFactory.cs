namespace MilieuFourthWPF
{
    public class LoginAndRegViewModelFactory : IViewModelFactory<LoginAndRegViewModel>
    {
        //private INavigationService _navigationService;
        //public LoginAndRegViewModelFactory(INavigationService navigationService)
        //{
        //    _navigationService = navigationService;
        //}
        public LoginAndRegViewModel CreateViewModel()
        {
            //return new LoginAndRegViewModel(_navigationService);
            return new LoginAndRegViewModel();
        }
    }
}
