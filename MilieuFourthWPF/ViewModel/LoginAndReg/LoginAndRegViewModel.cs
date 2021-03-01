using Microsoft.Extensions.DependencyInjection;
using Milieu.Models.Account.ClientSide;
using Milieu.Models.Account.Requests;
using Milieu.Models.Responses;
using Milieu.Models.Routes;
using MilieuFourthWPF.Database.Repos;
using MilieuFourthWPF.Helpers;
using Newtonsoft.Json;
using System.Security;
using System.Threading.Tasks;

namespace MilieuFourthWPF
{
    // Не нравится что VM отвечает за две функции
    public class LoginAndRegViewModel : BaseViewModel
    {

        #region Constructor

        public LoginAndRegViewModel()
        {            
        }

        #endregion

        #region Private Fields        

        #endregion

        #region Public Properties
        public string EmailLogin { get; set; }
        public SecureString PasswordLogin { private get; set; }

        public string EmailRegistration { get; set; }
        public SecureString PasswordRegistration { private get; set; }
        public SecureString ConfirmPasswordRegistration { private get; set; }

        #endregion

        #region Commands

        private IAsyncCommand _loginCommand = null;
        public IAsyncCommand LoginCommand => _loginCommand ??
            (_loginCommand = new AsyncCommand(_loginMethodAsync));

        private async Task _loginMethodAsync()
        {
            string urlLogin = ApiRouteHelper.GetAccountControllerLoginRoute();

            var response = await WebRequests.PostJsonAsync
            (
                urlLogin,
                new LoginApiRequest
                {
                    Email = EmailLogin,
                    Password = PasswordLogin.Unsecure()
                });

            if (response.IsSuccessStatusCode)
            {
                AuthenticateApiResponse result = JsonConvert.DeserializeObject<AuthenticateApiResponse>(response.Content.ReadAsStringAsync().Result);                
                var appVM = DI.ServiceProvider.GetService<ApplicationWindowViewModel>();
                await appVM.EntryToAppAsync(result.Email, result.Jwt, result.RefreshToken);                                
            }
            else
            {
                // Добавить в чём ошибка
            }
        }

        private IAsyncCommand _registerCommand = null;
        public IAsyncCommand RegisterCommand => _registerCommand ??
            (_registerCommand = new AsyncCommand(_registerMethodAsync));

        private async Task _registerMethodAsync()
        {
            string urlRegister = ApiRouteHelper.GetAccountControllerRegisterRoute();

            var response = await WebRequests.PostJsonAsync
                (urlRegister,
                new RegisterApiRequest
                {
                    Email = EmailRegistration,
                    Password = PasswordRegistration.Unsecure(),
                    ConfirmPassword = ConfirmPasswordRegistration.Unsecure()
                });

            AuthenticateApiResponse result = JsonConvert.DeserializeObject<AuthenticateApiResponse>(response.Content.ReadAsStringAsync().Result);

            if (result.ApiResponseDefault.Successful)
            {                                           
                ApplicationWindowViewModel appVM = DI.ServiceProvider.GetService<ApplicationWindowViewModel>();
                await appVM.EntryToAppAsync(result.Email, result.Jwt, result.RefreshToken);
            }

        }

        
        #endregion


    }
}
