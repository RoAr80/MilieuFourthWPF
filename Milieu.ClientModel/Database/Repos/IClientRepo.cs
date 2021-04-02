using Milieu.ClientModels.ClientSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milieu.ClientModels.Database.Repos
{
    public interface IClientRepo
    {
        Task UpdateTokensAsync(LoginCredentialsDataModel LoginCred, string Jwt, string RefreshToken);
        Task UpdateUserWhenLogin(long userIdWhichUpdate, string Jwt, string RefreshToken);
        Task UpdateEmailAndTokenAsync(LoginCredentialsDataModel LoginCred);
        Task UpdateIsLogoutAsync(long Id, bool IsLogout);
        Task UpdateLastEntryToNowAsync(long Id);
        Task UpdateOrAddUserAsync(LoginCredentialsDataModel LoginCred);
        //ToDo:  Всё сделать на Task
        Task<LoginCredentialsDataModel> GetUserLoginCredentialsAsync(long id);
        Task<LoginCredentialsDataModel> GetUserLoginCredentialsAsync(string Email);
        Task<LoginCredentialsDataModel> GetLastEntryUserAsync();        
        string GetEmail(long Id);        
    }
}
