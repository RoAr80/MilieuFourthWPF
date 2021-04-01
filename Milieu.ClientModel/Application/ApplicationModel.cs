using Milieu.ClientModels.ApiRouteHelpers;
using Milieu.ClientModels.ClientSide;
using Milieu.ClientModels.Database.Repos;
using Milieu.ClientModels.Web;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Milieu.ClientModels
{
    public class ApplicationModel
    {
        public long UserSessionLocalId { get; set; }
        //public LoginCredentialsDataModel CurrentUserLoginCredentials { get; set; }
        private IClientRepo _clientRepo { get; set; }
        private IWebRequestsService _webRequestsService { get; set; }
        public ApplicationModel(IClientRepo clientRepo, IWebRequestsService webRequestsService)
        {
            _clientRepo = clientRepo;
            _webRequestsService = webRequestsService;
            TryToAutoLoginAsync();
        }        

        //ToDo: переназвать
        public async Task EntryToAppAsync(string Email, string Jwt, string RefreshToken)
        {
            LoginCredentialsDataModel loginCredentials = new LoginCredentialsDataModel()
            {
                Email = Email,
                Jwt = Jwt,
                RefreshToken = RefreshToken,
                LastEntry = DateTime.Now,
                IsLogout = false
            };
            
            await _clientRepo.UpdateOrAddUserAsync(loginCredentials);
            //PageChanged?.Invoke(this, new ApplicationWindowEventArgs(prevPage));            
        }

        public async Task<bool> TryToAutoLoginAsync()
        {
            var user = await _clientRepo.GetLastEntryUserAsync();

            if (user == null || user.IsLogout)
                return false;

            var jwt = user.Jwt;
            var urlAmIAuth = ApiRouteHelper.GetAccountControllerAmIAuthorized();
            var response = await _webRequestsService.GetAsyncJson(urlAmIAuth, jwt);
            if (response.IsSuccessStatusCode)
            {
                await EntryToAppAsync(user.Email, user.Jwt, user.RefreshToken);
                return true;
            }    
            else
            {
                //ToDo: создать Logout метод
                //Попробовать через refreshtoken запрыгнуть                
                var urlForJwtAndRt = ApiRouteHelper.GetAccountControllerGetJwtAndRtViaRt();
                var responseRefresh = await _webRequestsService.PostJsonAsync(urlForJwtAndRt, new AuthenticateApiRequest { Email = user.Email, RefreshToken = user.RefreshToken });
                if (responseRefresh.IsSuccessStatusCode)
                {
                    AuthenticateApiResponse resultRefresh = JsonConvert.DeserializeObject<AuthenticateApiResponse>(responseRefresh.Content.ReadAsStringAsync().Result);
                    await _clientRepo.UpdateTokensAsync(user, resultRefresh.Jwt, resultRefresh.RefreshToken);
                    await EntryToAppAsync(user.Email, user.Jwt, user.RefreshToken);
                    // ToDo: заглушка проверить.
                    return true;
                }
                else
                {
                    // ToDo: заглушка проверить
                    return false;
                }
                    //CurrentPage = ApplicationWindowPageEnum.LoginAndRegPage;
            }
        }
    }
}
