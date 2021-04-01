namespace Milieu.ClientModels.Web
{
    public class AuthenticateApiRequest
    {        
        public string Email { get; set; }

        public string RefreshToken { get; set; }

        public AuthenticateApiRequest()
        {

        }

        public AuthenticateApiRequest(string email)
        {
            Email = email;
        }

        public AuthenticateApiRequest(string email, string refreshToken)
        {
            Email = email;
            RefreshToken = refreshToken;
        }

    }
}
