using System.Threading.Tasks;
using MedGame.Dots.Authentication;

namespace MedGame.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> AuthenticationAsync(string username, string password);
    }
}
