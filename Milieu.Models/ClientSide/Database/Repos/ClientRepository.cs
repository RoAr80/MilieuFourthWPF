using Milieu.Models.Account.ClientSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milieu.Models.ClientSide.Database.Repos
{
    public class ClientRepository : IClientRepo
    {
        private ClientDbContext _clientDbContext;

        public ClientRepository(ClientDbContext clientDbContext)
        {
            _clientDbContext = clientDbContext;
            _clientDbContext.Database.EnsureCreated();
        }

        public async Task AddUserAsync(LoginCredentialsDataModel LoginCred)
        {            
            await _clientDbContext.LoginCredentials.AddAsync(LoginCred);
            _clientDbContext.SaveChanges();
        }

        public async Task RegisterUserAsync(LoginCredentialsDataModel LoginCred)
        {
            LoginCredentialsDataModel loginCred = new LoginCredentialsDataModel 
            { 
                Email = LoginCred.Email,
                Jwt = LoginCred.Jwt,
                RefreshToken = LoginCred.RefreshToken,
                LastEntry = DateTime.Now,
                IsLogout = false,
            };
            await _clientDbContext.LoginCredentials.AddAsync(loginCred);
            _clientDbContext.SaveChanges();
        }

        // ToDo: Подумать ещё раз        
        public async Task UpdateTokensAsync(LoginCredentialsDataModel LoginCred, string Jwt, string RefreshToken)
        {
            LoginCredentialsDataModel loginCred = await _clientDbContext.LoginCredentials.FindAsync(LoginCred.Id);
            loginCred.Jwt = Jwt;            
            loginCred.RefreshToken = RefreshToken;

            await _clientDbContext.SaveChangesAsync();
        }

        public async Task UpdateUserWhenLogin(long userIdWhichUpdate, string Jwt, string RefreshToken)
        {
            LoginCredentialsDataModel loginCred = await _clientDbContext.LoginCredentials.FindAsync(userIdWhichUpdate);
            loginCred.Jwt = Jwt;
            loginCred.RefreshToken = RefreshToken;

            await _clientDbContext.SaveChangesAsync();
        }

        public async Task UpdateIsLogoutAsync(long Id, bool IsLogout )
        {
            LoginCredentialsDataModel loginCred = await _clientDbContext.LoginCredentials.FindAsync(Id);
            loginCred.IsLogout = IsLogout;

            await _clientDbContext.SaveChangesAsync();
        }

        public async Task UpdateEmailAndTokenAsync(LoginCredentialsDataModel LoginCred)
        {
            LoginCredentialsDataModel loginCred = await _clientDbContext.LoginCredentials.FindAsync(LoginCred.Id);
            loginCred.Email = LoginCred.Email;
            loginCred.Jwt = LoginCred.Jwt;

            await _clientDbContext.SaveChangesAsync();

        }

        public async Task UpdateLastEntryToNowAsync(long Id)
        {
            LoginCredentialsDataModel loginCred = await _clientDbContext.LoginCredentials.FindAsync(Id);
            loginCred.LastEntry = DateTime.Now;

            await _clientDbContext.SaveChangesAsync();

        }

        public async Task<LoginCredentialsDataModel> GetUserLoginCredentialsAsync(long Id)
        {
            LoginCredentialsDataModel user = await _clientDbContext.LoginCredentials.FindAsync(Id);
            return user;
        }

        public async Task<LoginCredentialsDataModel> GetUserLoginCredentialsAsync(string Email)
        {
            LoginCredentialsDataModel user = await _clientDbContext.LoginCredentials.FindAsync(Email);
            return user;
        }        

        public string GetEmail(long Id)
        {
            LoginCredentialsDataModel user = _clientDbContext.LoginCredentials.FirstOrDefault(creds => creds.Id == Id);
            return user.Email;
        }       

        public async Task<LoginCredentialsDataModel> GetLastEntryUserAsync()
        {
            return await Task.Run(() => _clientDbContext.LoginCredentials.OrderByDescending(f => f.LastEntry).FirstOrDefault());            
        }

        public async Task UpdateOrAddUserAsync(LoginCredentialsDataModel LoginCred)
        {
            LoginCredentialsDataModel loginCred = await (Task.Run(() => _clientDbContext.LoginCredentials.SingleOrDefault(creds => creds.Email == LoginCred.Email)));
            if(loginCred != null)
            {
                loginCred.Jwt = LoginCred.Jwt;
                loginCred.RefreshToken = LoginCred.RefreshToken;
                loginCred.IsLogout = LoginCred.IsLogout;
                loginCred.LastEntry = LoginCred.LastEntry;
            }
            else
            {
                await _clientDbContext.LoginCredentials.AddAsync(LoginCred);
            }
            await _clientDbContext.SaveChangesAsync();
        }
    }
}
