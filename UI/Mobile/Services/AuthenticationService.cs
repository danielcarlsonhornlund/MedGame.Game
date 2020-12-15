using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MedGame.Dots.Authentication;
using MedGame.DTO.User;
using MedGame.Dtos.Authentication;
using MedGame.Managers;
using MedGame.Services.Interfaces;
using MedGame.Settings;
using Newtonsoft.Json;

namespace MedGame.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// Calls the backend to validate credentials for Authentication.
        /// </summary>
        /// <param name="username">The supplied user name</param>
        /// <param name="password">The supplied password</param>
        /// <returns></returns>
        public async Task<AuthenticationResult> AuthenticationAsync(string username, string password)
        {
            var authResult = new AuthenticationResult();

            try
            {
                var AuthenticationModel = new AuthenticationRequestModel { Username = username, Password = password };

                var response = await _httpClient.PostAsync(Constants.AuthenticationMicroservice.AuthenticationLoginEndpoint, new StringContent(AuthenticationModel.ToJson(), Encoding.UTF8, "application/json"));
                authResult = await HandleAuthenticationResponse(response);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return authResult;
        }

        /// <summary>
        /// After a Authentication/redeem request, read and parse
        /// the content and set new access and refresh tokens.
        /// </summary>
        public static async Task<AuthenticationResult> HandleAuthenticationResponse(HttpResponseMessage response)
        {
            var authResult = new AuthenticationResult();

            if (response.IsSuccessStatusCode)
            {
                string token = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(token))
                {
                    authResult.Success = true;
                    authResult.IsForbidden = false;
                    authResult.Token = token;

                    HttpClientManager.SetToken(authResult.Token);
                }
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                authResult.IsForbidden = true;
                authResult.Success = false;
                authResult.Token = "Forbidden";
            }

            return authResult;
        }
    }
}
