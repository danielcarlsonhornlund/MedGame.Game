using MedGame.GameLogic;
using MedGame.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MedGame.Services
{
    public class RESTClient
    {
        private HttpClient client = new HttpClient();

        //public static string Url { get; set; } = "http://medgame.azurewebsites.net/api/player";
        public static string UrlFacebook { get; set; } = "http://medgame.azurewebsites.net/api/facebook/signin";

        public string Url { get; set; } = "https://localhost:44350/api/player";

        public async Task<HttpResponseMessage> SignIn(string email, string password)
        {
            string fullUrl = Url + $"/signin/{email}/{password}";
            HttpResponseMessage httpResponseMessage = await client.GetAsync(fullUrl);
            return httpResponseMessage;
        }

        public async Task<HttpResponseMessage> SignUp(string email, string password)
        {
            string fullUrl = Url + $"/signup/{email}/{password}";
            HttpResponseMessage httpResponseMessage = await client.GetAsync(fullUrl);
            return httpResponseMessage;
        }


        public async Task<HttpResponseMessage> Update(Player player)
        {

            string fullUrl = Url + "/update";
            
            var httpClient = new HttpClient();
            string playerAsJson = JsonConvert.SerializeObject(player);

            StringContent content = new StringContent(playerAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PutAsync(fullUrl, content);

            string result = await httpResponseMessage.Content.ReadAsStringAsync();

            return httpResponseMessage;
        }
    }
}