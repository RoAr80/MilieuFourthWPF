using Milieu.Models.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilieuFourthWPF.Helpers
{
    public static class ApiRouteHelper
    {
        public readonly static string BaseUrl = DI.Configuration["RemoteServer:DomainName"];

        public static string GetAccountControllerRegisterRoute()
        {
            return BaseUrl + ApiRoutes.AccountControllerRegister;
        }

        public static string GetAccountControllerLoginRoute()
        {
            return BaseUrl + ApiRoutes.AccountControllerLogin;
        }

        public static string GetAccountControllerAmIAuthorized()
        {
            return BaseUrl + ApiRoutes.AccountControllerAmIAuthorized;
        }

        public static string GetAccountControllerGetJwtAndRtViaRt()
        {
            return BaseUrl + ApiRoutes.AccountControllerGetJwtAndRtViaRt;
        }

    }
}
