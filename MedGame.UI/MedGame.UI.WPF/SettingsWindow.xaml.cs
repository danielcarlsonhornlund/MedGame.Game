using MedGame.GameLogic;
using MedGame.Models;
using MedGame.Services;
using System.Windows;
using System.Windows.Input;

namespace MedGame.UI.WPF
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        RESTClient RestClient = new RESTClient();
        LoadingWindow LoadingWindow = new LoadingWindow();

        public SettingsWindow()
        {
            InitializeComponent();

            TextBoxFacebookFullName.Text = GamePlay.Player.FacebookFullName;
            TextBoxFacebookEmail.Text = GamePlay.Player.FacebookEmail;
            TextBoxFacebookGender.Text = GamePlay.Player.FacebookGender;
            TextBoxAddress.Text = GamePlay.Player.Address;
            TextBoxFacebookDateOfBirth.Text = GamePlay.Player.FacebookDateOfBirth;
            TextBoxUsername.Text = GamePlay.Player.UserName;
        }
        private void IconPlay_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PlayWindow playWindow = new PlayWindow();
            playWindow.Show();
            this.Close();
        }

        private void IconMunk_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MunkWindow MunkWindow = new MunkWindow();
            MunkWindow.Show();
            this.Close();
        }

        private void IconStatistics_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            StatisticsWindow StatisticsWindow = new StatisticsWindow();
            StatisticsWindow.Show();
            this.Close();
        }

        private void IconShare_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ShareWindow ShareWindow = new ShareWindow();
            ShareWindow.Show();
            this.Close();
        }

        private void IconSettings_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SettingsWindow SettingsWindow = new SettingsWindow();
            SettingsWindow.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            GamePlay.Player.FacebookFullName = TextBoxFacebookFullName.Text;
            GamePlay.Player.FacebookEmail = TextBoxFacebookEmail.Text;
            GamePlay.Player.FacebookGender = TextBoxFacebookGender.Text;
            GamePlay.Player.Address = TextBoxAddress.Text;
            GamePlay.Player.FacebookDateOfBirth = TextBoxFacebookDateOfBirth.Text;
            GamePlay.Player.UserName = TextBoxUsername.Text;

            await FileHandler.SavePlayerToFile(GamePlay.Player, GamePlay.Player.UserName);

            MunkWindow munkWindow = new MunkWindow();
            munkWindow.Show();
            this.Close();
        }
    }
}
