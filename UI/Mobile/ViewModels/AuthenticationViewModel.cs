using MedGame.Interfaces;
using MedGame.Services;
using MedGame.Services.Interfaces;
using MedGame.Settings;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MedGame.ViewModels
{
    public class AuthenticationViewModel : BaseViewModel
    {
        readonly IAuthenticationService _authenticationService;

        readonly IIoTHubService _ioTHubService;
        private readonly IUserManagementService _userManagementService;

        public ICommand AuthenticationCommand { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ImageNFC { get; set; } = "nfc1.png";
        bool _isRefreshing;

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set => SetProperty(ref _isRefreshing, value);
        }

        public AuthenticationViewModel()
        { }

        public AuthenticationViewModel(IAuthenticationService authenticationService, IIoTHubService ioTHubService, IUserManagementService userManagementService)
        {
            _authenticationService = authenticationService;
            _ioTHubService = ioTHubService;
            _userManagementService = userManagementService;

            //Temporary to avoid having to enter it every time
            Username = "Admin@MedGame.com";
            Password = "Password@";

            IsRefreshing = false;
            AuthenticationCommand = new Command(async () =>
            {
                IsRefreshing = true;
                await Authentication(Username, Password);
                await GetIoTHubexerciseMachineName("ryggmaskin1");
                IsRefreshing = false;
            });
        }

        private async Task GetIoTHubexerciseMachineName(string exerciseMachineName)
        {
            IsBusy = true;

            if (string.IsNullOrEmpty(exerciseMachineName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "AppResources.AuthenticationNoUsernamePasswordAlertText", "AppResources.OK");
                return;
            }

            var exerciseMachineObject = await _ioTHubService.GetIoTHubDevice(exerciseMachineName);
            await Application.Current.MainPage.DisplayAlert("Device:", exerciseMachineObject.ConnectionString, "OK");

            IsBusy = false;
        }

        public async Task Authentication(string username, string password)
        {
            IsBusy = true;

            var authResult = await _authenticationService.AuthenticationAsync(username, password);

            if (authResult.Success)
            {
                Gameplay.User = await _userManagementService.GetUserByMail(username);
                Gameplay.AuthenticationResult = authResult;
                var user = JsonConvert.SerializeObject(Gameplay.User, Formatting.Indented);
                await Application.Current.MainPage.DisplayAlert("User:", user, "OK");
                await Application.Current.MainPage.DisplayAlert("Token:", Gameplay.AuthenticationResult.Token, "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("User not authenticated:", "Not auth", "OK");
            }

            IsBusy = false;
        }
    }
}