using Milieu.ClientModels;
using Milieu.ClientModels.ClientSide;
using Milieu.ClientModels.Login;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MilieuFourthWPF
{
    //public class ApplicationWindowViewModel : BaseViewModel
    public class ApplicationWindowViewModel : BaseViewModel
    {        
        private ApplicationModel _applicationModel;
        private LoginModel _loginModel;
        public long UserSessionLocalId { get; set; }
        public LoginCredentialsDataModel CurrentUserLoginCredentials { get; set; }
        public override ApplicationWindowControlEnum ApplicationWindowControlEnumName => ApplicationWindowControlEnum.ApplicationControl;

        public ApplicationWindowViewModel(INavigationService navigationService, ApplicationModel applicationModel, LoginModel loginModel)
        {            
            _navigationService = navigationService;
            _applicationModel = applicationModel;
            _loginModel = loginModel;
            init();
        }        

        #region Methods

        private async Task init()
        {

            //bool Successful = await _loginModel.TryToAutoLoginAsync();
            // Заглушка
            bool Successful = true;
            if (Successful)
            {
                _navigationService.NavigateTo(ApplicationWindowControlEnum.Home);
            }
            else
            {
                _navigationService.NavigateTo(ApplicationWindowControlEnum.LoginAndRegistration);
            }
        }

        
        #endregion       

        
    }
}
