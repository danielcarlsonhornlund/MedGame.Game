using Autofac;
using MedGame.Interfaces;
using MedGame.Services;
using MedGame.Services.Interfaces;
using MedGame.ViewModels;
using System.ComponentModel;
using System.Net.Mqtt;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedGame.Views
{
    [DesignTimeVisible(true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthenticationPage : ContentPage
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IIoTHubService _ioTHubService;
        private readonly IUserManagementService _userManagementService;

        public AuthenticationPage(Autofac.IContainer container)
        {
            InitializeComponent();
            _authenticationService = container.Resolve<IAuthenticationService>();
            _ioTHubService = container.Resolve<IIoTHubService>();
            _userManagementService = container.Resolve<IUserManagementService>();

            BindingContext = new AuthenticationViewModel(_authenticationService, _ioTHubService, _userManagementService);
        }
        //protected async override void OnAppearing()
        //{

        //}

        //private void SendMessageToStartDeviceAsync(MqttApplicationMessage message)
        //{
        //    string messageAsString = Encoding.UTF8.GetString(message.Payload);

        //    Device.BeginInvokeOnMainThread(async () =>
        //    {
        //        await DisplayAlert($"Message recieved on topic: {message.Topic}", messageAsString, "Ok");
        //    });
        //}

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }
    }
}