using Milieu.ClientModels.Registration;

namespace MilieuFourthWPF
{
    public class LoginAndRegViewModelFactory : IViewModelFactory<LoginAndRegViewModel>
    {
        private RegistrationModel _registrationModel;

        public LoginAndRegViewModelFactory(RegistrationModel registrationModel)
        {
            _registrationModel = registrationModel;
        }
        public LoginAndRegViewModel CreateViewModel()
        {
            //return new LoginAndRegViewModel(_navigationService);
            return new LoginAndRegViewModel(_registrationModel);
        }
    }
}
