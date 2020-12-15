using MedGame.Dtos.IoTHub;
using System.Threading.Tasks;

namespace MedGame.Services
{
    public interface IIoTHubService
    {
        Task<IoTHubDevice> GetIoTHubDevice(string iotHubDeviceName);
    }
}