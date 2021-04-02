using Milieu.ClientModels.Login;
using Milieu.ClientModels.Registration;

namespace MilieuFourthWPF
{
    public class LoginAndRegViewModelFactory : IViewModelFactory<LoginAndRegViewModel>
    {
        private RegistrationModel _registrationModel;
        private LoginModel _loginModel;

        public LoginAndRegViewModelFactory(RegistrationModel registrationModel, LoginModel loginModel)
        {
            _registrationModel = registrationModel;
            _loginModel = loginModel;
        }
        public LoginAndRegViewModel CreateViewModel()
        {
            //return new LoginAndRegViewModel(_navigationService);
            return new LoginAndRegViewModel(_registrationModel, _loginModel);
        }
    }
}
