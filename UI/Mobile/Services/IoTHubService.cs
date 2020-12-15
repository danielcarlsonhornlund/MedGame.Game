using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MedGame.Dtos.IoTHub;
using MedGame.Settings;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;

namespace MedGame.Services
{
    public class IoTHubService : IIoTHubService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private static ServiceClient ServiceClient;


        /// <summary>
        /// Calls the backend to validate credentials for Authentication.
        /// </summary>
        /// <param name="username">The supplied user name</param>
        /// <param name="password">The supplied password</param>
        /// <returns></returns>
        public async Task<IoTHubDevice> GetIoTHubDevice(string iotHubDeviceName)
        {
            var fullURL = Constants.IoTHub.GetIotHubDevices + iotHubDeviceName;

            try
            {
                var iotHubDevice = await _httpClient.GetStringAsync(fullURL);

                var iotHubDeviceObject = IoTHubDevice.ConvertToIoTHubDeviceObject(iotHubDevice);
                return iotHubDeviceObject;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }

        public async Task<IoTHubDevice> GetIoTHubDeviceStatus(string iotHubDeviceName)
        {
            var device = await GetIoTHubDevice(iotHubDeviceName);

            if (device != null)
            {
                return device;
            }

            return null;
        }

        public async Task SendDataToIoTHubDevice(IoTHubDevice ioTHubDevice, string messageToSend)
        {
            using (DeviceClient deviceClient = DeviceClient.CreateFromConnectionString(Constants.IoTHub.IoTHubConnectionString, Microsoft.Azure.Devices.Client.TransportType.Mqtt))
            {
                var message = new Microsoft.Azure.Devices.Client.Message(Encoding.ASCII.GetBytes(messageToSend));
                message.Properties.Add("Device", ioTHubDevice.DeviceName);
                await deviceClient.SendEventAsync(message);
            }

            Console.WriteLine("Data sent to iothubdevice");
        }

        public async Task<CloudToDeviceMethodResult> SendStartRequestToDevice(IoTHubDevice ioTHubDevice)
        {
            try
            {
                ServiceClient = ServiceClient.CreateFromConnectionString(Constants.IoTHub.IoTHubConnectionString);

                var methodInvocation = new CloudToDeviceMethod("Start") { ResponseTimeout = TimeSpan.FromSeconds(30) };
                methodInvocation.SetPayloadJson("10");

                var result = await ServiceClient.InvokeDeviceMethodAsync(ioTHubDevice.DeviceName, methodInvocation);

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
