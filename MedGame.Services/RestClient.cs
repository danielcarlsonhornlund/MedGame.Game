using MedGame.GameLogic;
using MedGame.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MedGame.Services
{
    public class RESTClient
    {
        private HttpClient client = new HttpClient();

        public static string Url { get; set; } = "http://medgame.azurewebsites.net/api/player";
        public static string UrlFacebook { get; set; } = "http://medgame.azurewebsites.net/api/facebook/signin";

       // public string Url { get; set; } = "https://localhost:44350/api/player";

        public bool CheckForInternetConnection()
        {
            try
            {
                return new Ping().Send(Url).Status == IPStatus.Success;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Player> SignIn(string email, string password)
        {
            string fullUrl = Url + $"/signin/{email}/{password}";
            HttpResponseMessage httpResponseMessage = await client.GetAsync(fullUrl);

            string result = await httpResponseMessage.Content.ReadAsStringAsync();
            Player playerResult = JsonConvert.DeserializeObject<Player>(result);

            return playerResult;
        }

        public async Task<Player> SignUp(string email, string password)
        {
            string fullUrl = Url + $"/signup/{email}/{password}";
            HttpResponseMessage httpResponseMessage = await client.GetAsync(fullUrl);

            string result = await httpResponseMessage.Content.ReadAsStringAsync();
            Player playerResult = JsonConvert.DeserializeObject<Player>(result);

            return playerResult;
        }


        public async Task<Player> Update(Player player)
        {
            string fullUrl = Url;

            var httpClient = new HttpClient();
            string playerAsJson = JsonConvert.SerializeObject(player);

            StringContent content = new StringContent(playerAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PutAsync(fullUrl, content);

            string result = await httpResponseMessage.Content.ReadAsStringAsync();

            Player playerResult = null;

            try
            {
                playerResult = JsonConvert.DeserializeObject<Player>(result);
            }
            catch (Exception ex)
            {
                playerResult.PlayerMessage = "Could not update player: "+Environment.NewLine + ex.Message + Environment.NewLine+ result;
            }
             

            return playerResult;
        }
    }
}