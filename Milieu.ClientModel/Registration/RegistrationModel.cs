using Milieu.ClientModels.ApiRouteHelpers;
using Milieu.ClientModels.ExtensionMethods;
using Milieu.ClientModels.Web;
using Newtonsoft.Json;
using System.Security;
using System.Threading.Tasks;

namespace Milieu.ClientModels.Registration
{
    public class RegistrationModel
    {
        IWebRequestsService _webRequestsService;
        public RegistrationModel(IWebRequestsService webRequestsService)
        {
            _webRequestsService = webRequestsService;
        }
        public string Email { get; set; }
        public SecureString Password { get; set; }
        public SecureString ConfirmPassword { get; set; }

        //public async Task<bool> RegisterAsync(string email, SecureString password, SecureString confirmPassword)
        //{
        //    string urlRegister = ApiRouteHelper.GetAccountControllerRegisterRoute();

        //    var response = await _webRequestsService.PostJsonAsync
        //        (urlRegister,
        //        new RegisterApiRequest
        //        {
        //            Email = email,
        //            Password = password.Unsecure(),
        //            ConfirmPassword = confirmPassword.Unsecure()
        //        });

        //    AuthenticateApiResponse result = JsonConvert.DeserializeObject<AuthenticateApiResponse>(response.Content.ReadAsStringAsync().Result);

        //    if (result.ApiResponseDefault.Successful)
        //    {                
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        public async Task<bool> RegisterAsync()
        {
            string urlRegister = ApiRouteHelper.GetAccountControllerRegisterRoute();

            var response = await _webRequestsService.PostJsonAsync
                (urlRegister,
                new RegisterApiRequest
                {
                    Email = Email,
                    Password = Password.Unsecure(),
                    ConfirmPassword = ConfirmPassword.Unsecure()
                });

            AuthenticateApiResponse result = JsonConvert.DeserializeObject<AuthenticateApiResponse>(response.Content.ReadAsStringAsync().Result);

            if (result.ApiResponseDefault.Successful)
            {
                return true;
            }
            else
                return false;
        }
    }
}
