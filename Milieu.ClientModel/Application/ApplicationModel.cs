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
            
        }                
    }
}
