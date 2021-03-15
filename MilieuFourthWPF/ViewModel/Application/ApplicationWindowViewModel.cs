using Microsoft.Extensions.DependencyInjection;
using Milieu.Models.Account.ClientSide;
using Milieu.Models.Requests;
using Milieu.Models.Responses;
using MilieuFourthWPF.Database.Repos;
using MilieuFourthWPF.Helpers;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MilieuFourthWPF
{
    public class ApplicationWindowViewModel : BaseViewModel
    {
        public long UserSessionLocalId { get; set; }
        public LoginCredentialsDataModel CurrentUserLoginCredentials { get; set; }
        private IClientRepo _clientRepo { get; set; }        
        public ApplicationWindowPageEnum CurrentPage { get; set; } = ApplicationWindowPageEnum.LoginAndRegPage;
        public ApplicationWindowViewModel()
        {
            _clientRepo = DI.ServiceProvider.GetService<IClientRepo>();
        }

        public string Usering { get; set; }


        #region Methods

        public void ChangeApplicationWindowPageTo(ApplicationWindowPageEnum page)
        {
            ApplicationWindowPageEnum prevPage = CurrentPage;
            CurrentPage = page;
            PageChanged?.Invoke(this, new ApplicationWindowEventArgs(prevPage));
        }

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

            ApplicationWindowPageEnum prevPage = CurrentPage;
            CurrentPage = ApplicationWindowPageEnum.Application;
            await _clientRepo.UpdateOrAddUserAsync(loginCredentials);
            PageChanged?.Invoke(this, new ApplicationWindowEventArgs(prevPage));            
        }

        public async Task TryToAutoLoginAsync()
        {            
            var user = await _clientRepo.GetLastEntryUserAsync();

            if (user == null || user.IsLogout) 
                return;            

            var jwt = user.Jwt; 
            var urlAmIAuth = ApiRouteHelper.GetAccountControllerAmIAuthorized();
            var response = await WebRequests.GetAsyncJson(urlAmIAuth, jwt);                        
            if (response.IsSuccessStatusCode)
                await EntryToAppAsync(user.Email, user.Jwt, user.RefreshToken);
            else
            {
                //ToDo: создать Logout метод
                //Попробовать через refreshtoken запрыгнуть                
                var urlForJwtAndRt = ApiRouteHelper.GetAccountControllerGetJwtAndRtViaRt();
                var responseRefresh = await WebRequests.PostJsonAsync(urlForJwtAndRt, new AuthenticateApiRequest { Email = user.Email, RefreshToken = user.RefreshToken });
                if(responseRefresh.IsSuccessStatusCode)
                {
                    AuthenticateApiResponse resultRefresh = JsonConvert.DeserializeObject<AuthenticateApiResponse>(responseRefresh.Content.ReadAsStringAsync().Result);                    
                    await _clientRepo.UpdateTokensAsync(user, resultRefresh.Jwt, resultRefresh.RefreshToken);
                    await EntryToAppAsync(user.Email, user.Jwt, user.RefreshToken);
                }
                else
                    CurrentPage = ApplicationWindowPageEnum.LoginAndRegPage;
            }
        }
        #endregion

        #region Events
        public event EventHandler<ApplicationWindowEventArgs> PageChanged; 
        #endregion
    }
}
