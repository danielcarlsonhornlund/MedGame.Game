using MedGame.GameLogic;
using MedGame.Models;
using MedGame.Services;
using Newtonsoft.Json;
using System.Net.Http;
using System.Windows;

namespace MedGame.UI.WPF
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        RESTClient RestClient = new RESTClient();


        public SignInWindow()
        {
            InitializeComponent();
        }

        private async void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            LoadingCircleWindow.Show();
            
            HttpResponseMessage result = await RestClient.SignIn(TextBoxEmail.Text, TextBoxPassword.Password);

            CheckLogin(result);
        }

        private async void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        {
            HttpResponseMessage result = await RestClient.SignUp(TextBoxEmail.Text, TextBoxPassword.Password);
        }

        private async void CheckLogin(HttpResponseMessage result)
        {
            if (result.IsSuccessStatusCode)
            {
                string playerAsJson = await result.Content.ReadAsStringAsync();
                Game.Player = JsonConvert.DeserializeObject<Player>(playerAsJson);

                if (Game.Player.Email!= null)
                {

                    GameWindow GameWindow = new GameWindow();
                    GameWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Game.Player.PlayerMessage);
                }

            }
            else
            {
                string playerAsJson = await result.Content.ReadAsStringAsync();
            }

            LoadingCircleWindow.Hide();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void LabelLoginWithFacebook_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void LabelLoginWithFacebook_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FacebookLoginWindow facebookLoginWindow = new FacebookLoginWindow();
            facebookLoginWindow.ShowDialog();

            GameWindow GameWindow = new GameWindow();
            GameWindow.Show();

            this.Close();

        }
    }
}
