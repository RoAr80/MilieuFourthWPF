using Milieu.Models.Responses;

namespace Milieu.ClientModels.Web
{
    public class AuthenticateApiResponse
    {
        
        public DefaultApiResponse ApiResponseDefault { get; set; }
        public string Email { get; set; }
        public string Jwt { get; set; }
        public string RefreshToken { get; set; }

        public AuthenticateApiResponse()
        {

        }
        public AuthenticateApiResponse(string email, string jwt, string refreshToken)
        {
            ApiResponseDefault = new DefaultApiResponse();
            Email = email;
            Jwt = jwt;
            RefreshToken = refreshToken;
        }
    }
}
