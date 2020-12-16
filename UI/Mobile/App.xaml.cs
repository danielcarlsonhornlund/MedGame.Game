using Autofac;
using MedGame.Services;
using MedGame.Services.Interfaces;
using MedGame.Views;
using Xamarin.Forms;
using System.Net.Mqtt;
using System.Diagnostics;
using MedGame.Common.Helpers;
using System;
using System.Text;
using MedGame.Interfaces;
using LocalNotifications;

namespace MedGame
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Debug.WriteLine("test");

            var builder = new ContainerBuilder();
            builder.RegisterInstance<IAuthenticationService>(new AuthenticationService()).SingleInstance();
            builder.RegisterInstance<IIoTHubService>(new IoTHubService()).SingleInstance();
            builder.RegisterInstance<IUserManagementService>(new UserManagementService()).SingleInstance();

            DependencyService.Get<INotificationManager>().Initialize();

            var container = builder.Build();


            MainPage = new NotificationPage();
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
