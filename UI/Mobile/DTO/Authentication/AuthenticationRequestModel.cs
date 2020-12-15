using Newtonsoft.Json;

namespace MedGame.Dtos.Authentication
{
    public class AuthenticationRequestModel
    {
        public string Username { get; set;}

        public string Password { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
