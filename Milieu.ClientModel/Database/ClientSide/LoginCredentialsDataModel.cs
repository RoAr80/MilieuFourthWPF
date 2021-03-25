using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Milieu.ClientModels.ClientSide
{
    public class LoginCredentialsDataModel
    {
        public long Id { get; set; }        
        public string Email { get; set; }
        public string Jwt { get; set; }
        public string RefreshToken { get; set; }
        public DateTime LastEntry { get; set; }
        public bool IsLogout { get; set; }
    }
}
