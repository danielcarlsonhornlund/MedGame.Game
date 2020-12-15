using MedGame.DTO.AzureADUser;
using MedGame.DTO.User;
using MedGame.Interfaces;
using MedGame.Managers;
using MedGame.Settings;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MedGame.Services
{
    public class UserManagementService : IUserManagementService
    {
        public async Task<User> GetUserByMail(string mail)
        {
            var userByMail = await HttpClientManager.GetAsync(Constants.UsermanagementService.UserGetOneUserEndpoint + mail, new CancellationToken());
            var userContent = await userByMail.Content.ReadAsStringAsync();
            User user = JsonConvert.DeserializeObject<User>(userContent);

            if (user == null)
            {
                return new User();
            }

            return user;
        }

        public async Task<AzureADGet> GetAzureADUserByMail(string mail)
        {
            var userByMail = await HttpClientManager.GetAsync(Constants.UsermanagementService.UserGetOneAzureADUserEndpoint + mail, new CancellationToken());
            var userContent = await userByMail.Content.ReadAsStringAsync();
            AzureADGet user = JsonConvert.DeserializeObject<AzureADGet>(userContent);

            if (user == null)
            {
                return new AzureADGet();
            }

            return user;
        }
    }
}
