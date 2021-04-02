using Microsoft.Extensions.DependencyInjection;
using Milieu.ClientModels.Login;
using Milieu.ClientModels.Registration;
using Newtonsoft.Json;
using System.Security;
using System.Threading.Tasks;

namespace MilieuFourthWPF
{
    // Не нравится что VM отвечает за две функции
    public class LoginAndRegViewModel : BaseViewModel
    {
        public override ApplicationWindowControlEnum ApplicationWindowControlEnumName => ApplicationWindowControlEnum.LoginAndRegistration;


        #region Constructor

        public LoginAndRegViewModel(RegistrationModel registrationModel, LoginModel loginModel)
        {
            _registrationModel = registrationModel;
            _loginModel = loginModel;
        }

        #endregion

        #region Registration

        #region Private Fields        

        RegistrationModel _registrationModel;

        #endregion

        #region Public Properties

        public string EmailRegistration 
        { 
            get => _registrationModel.Email; 
            set => _registrationModel.Email = value; 
        }
        public SecureString PasswordRegistration 
        { 
            get => _registrationModel.Password; 
            set => _registrationModel.Password = value; 
        }
        public SecureString ConfirmPasswordRegistration
        {
            get => _registrationModel.ConfirmPassword;
            set => _registrationModel.ConfirmPassword = value;
        }

        #endregion

        #region Commands

        private IAsyncCommand _registerCommand = null;
        public IAsyncCommand RegisterCommand => _registerCommand ??
            (_registerCommand = new AsyncCommand(_registerMethodAndEntryAsync));

        private async Task _registerMethodAndEntryAsync()
        {
            bool isSuccess = await _registrationModel.RegisterAsync();

            if(isSuccess == true)
            {
                await _loginModel.LoginToAppOnServerAsync(EmailRegistration, PasswordRegistration);
                _navigationService.NavigateTo(ApplicationWindowControlEnum.Home);
            }

        }

        #endregion

        #endregion

        #region Login

        #region Private Fields

        LoginModel _loginModel;

        #endregion

        #region Public Properties
        public string EmailLogin { get; set; }
        public SecureString PasswordLogin { private get; set; }

        #endregion

        #region Commands

        private IAsyncCommand _loginCommand = null;
        public IAsyncCommand LoginCommand => _loginCommand ??
            (_loginCommand = new AsyncCommand(_loginMethodAsync));

        private async Task _loginMethodAsync()
        {
            await _loginModel.LoginToAppOnServerAsync(EmailLogin, PasswordLogin);
            _navigationService.NavigateTo(ApplicationWindowControlEnum.Home);
        }

        #endregion

        #endregion






    }
}
