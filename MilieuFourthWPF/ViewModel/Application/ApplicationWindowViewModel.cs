using Milieu.ClientModels.ClientSide;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MilieuFourthWPF
{
    //public class ApplicationWindowViewModel : BaseViewModel
    public class ApplicationWindowViewModel : BaseViewModel
    {
        public long UserSessionLocalId { get; set; }
        public LoginCredentialsDataModel CurrentUserLoginCredentials { get; set; }

        //public ApplicationWindowPageEnum CurrentPage { get; set; } = ApplicationWindowPageEnum.Application;
        //public BaseViewModel CurrentPage { get; set; } = new LoginAndRegViewModel();
        public BaseViewModel CurrentPage => _navigationService.CurrentPage;        

        public ApplicationWindowViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.NavigateTo(ApplicationWindowPageEnum.LoginAndRegPage);
        }        

        #region Methods

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

            //ApplicationWindowPageEnum prevPage = CurrentPage;
            //CurrentPage = ApplicationWindowPageEnum.Application;
            //await _clientRepo.UpdateOrAddUserAsync(loginCredentials);
            //PageChanged?.Invoke(this, new ApplicationWindowEventArgs(prevPage));            
        }

        public async Task TryToAutoLoginAsync()
        {            
            //var user = await _clientRepo.GetLastEntryUserAsync();

            //if (user == null || user.IsLogout) 
            //    return;            

            //var jwt = user.Jwt; 
            //var urlAmIAuth = ApiRouteHelper.GetAccountControllerAmIAuthorized();
            //var response = await WebRequests.GetAsyncJson(urlAmIAuth, jwt);                        
            //if (response.IsSuccessStatusCode)
            //    await EntryToAppAsync(user.Email, user.Jwt, user.RefreshToken);
            //else
            //{
            //    //ToDo: создать Logout метод
            //    //Попробовать через refreshtoken запрыгнуть                
            //    var urlForJwtAndRt = ApiRouteHelper.GetAccountControllerGetJwtAndRtViaRt();
            //    var responseRefresh = await WebRequests.PostJsonAsync(urlForJwtAndRt, new AuthenticateApiRequest { Email = user.Email, RefreshToken = user.RefreshToken });
            //    if(responseRefresh.IsSuccessStatusCode)
            //    {
            //        AuthenticateApiResponse resultRefresh = JsonConvert.DeserializeObject<AuthenticateApiResponse>(responseRefresh.Content.ReadAsStringAsync().Result);                    
            //        //await _clientRepo.UpdateTokensAsync(user, resultRefresh.Jwt, resultRefresh.RefreshToken);
            //        await EntryToAppAsync(user.Email, user.Jwt, user.RefreshToken);
            //    }
            //    else
            //        CurrentPage = ApplicationWindowPageEnum.LoginAndRegPage;
            //}
        }
        #endregion       
    }
}
