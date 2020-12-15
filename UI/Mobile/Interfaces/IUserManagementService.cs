using MedGame.DTO.User;
using System.Threading.Tasks;

namespace MedGame.Interfaces
{
    public interface IUserManagementService
    {
        Task<User> GetUserByMail(string mail);
    }
}