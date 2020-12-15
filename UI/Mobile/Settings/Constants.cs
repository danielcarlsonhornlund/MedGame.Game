using MedGame.Dots.Authentication;
using MedGame.DTO.AzureADUser;
using MedGame.DTO.User;

namespace MedGame.Settings
{
    public static class Constants
    {

        public static class IoTHub
        {
            public const string GetIotHubDevices = "http://MedGameiothub.azurewebsites.net/api/iothub/";
            public const string IoTHubConnectionString = "HostName=MedGameiothub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=R9Vrz6beac9GeyTqYtL+e9YqklvZ4GPpRPmGejPzkdA=";
        }


        public static class Settings
        {
            public const string StartDeviceTopic = "StartDeviceTopic";

            public const string HostMqttBroker = "test.mosquitto.org";

            public const string HostMqttBrokerLocal = "192.168.1.9";
        }

        public static class AuthenticationMicroservice
        {
            public const string AuthenticationLoginEndpoint = "https://MedGameauthapi.azurewebsites.net/api/Authentication/login/";
        }

        public static class UsermanagementService
        {
            public const string UserGetOneUserEndpoint = "https://MedGameusermanagementapi.azurewebsites.net/api/user/";
            public const string UserGetOneAzureADUserEndpoint = "https://MedGameusermanagementapi.azurewebsites.net/api/userpersoninfo/";
        }

    }

    public static class Gameplay
    {
        public static User User = new User();
        public static AzureADGet AzureADUser = new AzureADGet();
        public static AuthenticationResult AuthenticationResult = new AuthenticationResult();
    }

    public static class MachineConstants
    {
        public static string MachineId { get; set; }
    }
}
