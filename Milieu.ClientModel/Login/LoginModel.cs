using Milieu.ClientModels.ApiRouteHelpers;
using Milieu.ClientModels.ClientSide;
using Milieu.ClientModels.Database.Repos;
using Milieu.ClientModels.ExtensionMethods;
using Milieu.ClientModels.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Milieu.ClientModels.Login
{
    public class LoginModel
    {
        IClientRepo _clientRepo;
        IWebRequestsService _webRequestsService;
        public LoginModel(IClientRepo clientRepo, IWebRequestsService webRequestsService)
        {
            _clientRepo = clientRepo;
            _webRequestsService = webRequestsService;
        }

        private async Task WriteDataInDbWhenLoginAsync(LoginCredentialsDataModel loginData)
        {
            loginData.LastEntry = DateTime.Now;
            await _clientRepo.UpdateOrAddUserAsync(loginData);
        }

        public async Task<bool> LoginToAppOnServerAsync(string email, SecureString password)
        {
            //_webRequestsService.PostJsonAsync
            string urlLogin = ApiRouteHelper.GetAccountControllerLoginRoute();

            var response = await _webRequestsService.PostJsonAsync
            (
                urlLogin,
                new LoginApiRequest
                {
                    Email = email,
                    Password = password.Unsecure()
                });

            AuthenticateApiResponse result = JsonConvert.DeserializeObject<AuthenticateApiResponse>(response.Content.ReadAsStringAsync().Result);

            if (result.ApiResponseDefault.Successful)
            {
                LoginCredentialsDataModel loginData = new LoginCredentialsDataModel()
                {
                    Email = result.Email,
                    Jwt = result.Jwt,
                    RefreshToken = result.RefreshToken,
                };
                await WriteDataInDbWhenLoginAsync(loginData);
                return true;                           
            }
            else
            {
                // Добавить в чём ошибка
                return false;
            }

        }

        public async Task<bool> TryToAutoLoginAsync()
        {
            var user = await _clientRepo.GetLastEntryUserAsync();

            if (user == null || user.IsLogout)
                return false;
            
            var urlAmIAuth = ApiRouteHelper.GetAccountControllerAmIAuthorized();
            var response = await _webRequestsService.GetJsonAsync(urlAmIAuth, user.Jwt);
            if (response.IsSuccessStatusCode)
            {
                await _clientRepo.UpdateLastEntryToNowAsync(user.Id);
                return true;
            }
            else
            {
                //ToDo: создать Logout метод
                //Попробовать через refreshtoken запрыгнуть                
                var urlForJwtAndRt = ApiRouteHelper.GetAccountControllerGetJwtAndRtViaRt();
                AuthenticateApiRequest authenticateApiRequest = new AuthenticateApiRequest()
                {
                    Email = user.Email,
                    RefreshToken = user.RefreshToken,
                };

                var responseRefresh = await _webRequestsService.PostJsonAsync(urlForJwtAndRt, authenticateApiRequest);
                AuthenticateApiResponse resultRefresh = JsonConvert.DeserializeObject<AuthenticateApiResponse>(responseRefresh.Content.ReadAsStringAsync().Result);
                if (resultRefresh.ApiResponseDefault != null && resultRefresh.ApiResponseDefault.Successful)
                {
                    //await _clientRepo.UpdateTokensAsync(user, resultRefresh.Jwt, resultRefresh.RefreshToken);
                    await WriteDataInDbWhenLoginAsync(new LoginCredentialsDataModel
                    {
                        Email = user.Email,
                        Jwt = resultRefresh.Jwt,
                        RefreshToken = resultRefresh.RefreshToken,
                    });
                    return true;

                }
                else
                    return false;
            }
        }
    }
}
