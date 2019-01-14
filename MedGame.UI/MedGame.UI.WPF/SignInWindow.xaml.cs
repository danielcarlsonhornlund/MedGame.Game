using MedGame.GameLogic;
using MedGame.Models;
using MedGame.Services;
using Newtonsoft.Json;
using System;
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

            //if (!RestClient.CheckForInternetConnection())
            //{
            //    MessageBox.Show("Check your internet connection", "No connection found", MessageBoxButton.OK, MessageBoxImage.Information);
            //    Environment.Exit(0);
            //}
            //else
            //{
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            //}
        }

        private async void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            LoadingCircleWindow.Show();

            Player result = await RestClient.SignIn(TextBoxEmail.Text, TextBoxPassword.Password);

            CheckLogin(result);
        }

        private async void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        {
            Player result = await RestClient.SignUp(TextBoxEmail.Text, TextBoxPassword.Password);
        }

        private void CheckLogin(Player playerResult)
        {
            if (playerResult.Email != null)
            {
                Game.Player = playerResult;

                if (Game.Player.Email != null)
                {
                    MunkWindow MunkWindow = new MunkWindow();
                    MunkWindow.Show();

                    Game.Player.TotalDaysMissed = GameScoreCounter.CalculateMissedDates();
                    Game.Player.TotalHoursMissed = GameScoreCounter.CalculateMissedHours();
                    GameScoreCounter.CalculateMultiplicator();

                    this.Close();
                }
                else
                {
                    MessageBox.Show(Game.Player.PlayerMessage);
                }

                LoadingCircleWindow.Hide();
            }
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

                MunkWindow MunkWindow = new MunkWindow();
                MunkWindow.Show();

                this.Close();

            }
        }
    }
