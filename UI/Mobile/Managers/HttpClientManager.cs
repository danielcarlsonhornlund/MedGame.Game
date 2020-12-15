using MedGame.Settings;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedGame.Managers
{
    public class HttpClientManager
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public static void SetToken(string token)
        {
            if (!HttpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                HttpClient.DefaultRequestHeaders.Add("Authorization", token);
            }
        }

        /// <summary>
        /// Makes a GET request async to the supplied endpoint.
        /// </summary>
        /// <param name="endpoint">The specific api endpoint</param>
        public static async Task<HttpResponseMessage> GetAsync(string endpoint, CancellationToken cancellationToken)
        {
            var response = await HttpClient.GetAsync(endpoint, cancellationToken);

            return response;
        }

        /// <summary>
        /// Makes a POST request async to the supplied endpoint.
        /// </summary>
        /// <param name="endpoint">The specific api endpoint</param>
        /// <param name="payload">The payload to send as json string</param>
        public static async Task<HttpResponseMessage> PostAsync(string endpoint, string payload)
        {
            var response = await HttpClient.PostAsync(endpoint, new StringContent(payload, Encoding.UTF8, "application/json"));

            return response;
        }

        /// <summary>
        /// Makes a PUT request async to the supplied endpoint.
        /// </summary>
        /// <param name="endpoint">The specific api endpoint</param>
        /// <param name="payload">The payload to send as json string</param>
        public static async Task<HttpResponseMessage> PutAsync(string endpoint, string payload)
        {
            try
            {
                var response = await HttpClient.PutAsync(endpoint, new StringContent(payload, Encoding.UTF8, "application/json"));

                return response;
            }
            catch (Exception)
            {
                return new HttpResponseMessage();
            }
        }
    }
}
