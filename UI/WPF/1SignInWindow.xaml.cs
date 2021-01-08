using MedGame.GameLogic;
using MedGame.Models;
using MedGame.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        LoadingWindow LoadingWindow = new LoadingWindow();

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
            //}
        }

        private async void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            //Player result = await RestClient.SignIn(TextBoxEmail.Text, TextBoxPassword.Password);

            if (!File.Exists(TextBoxEmail.Text.MakeFullFileName()))
            {
                MessageBox.Show("User does not exist, pleas register a new user");
            }
            else
            {
                LoadingWindow.Show();
                GamePlay.Player = await FileHandler.LoadPlayerFromFile(TextBoxEmail.Text.MakeFullFileName());
                CheckLogin(GamePlay.Player);
            }
        }

        private async void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        {
            //Player result = await RestClient.SignUp(TextBoxEmail.Text, TextBoxPassword.Password);

            var newPlayer = CreateNewPlayer();

            await FileHandler.SavePlayerToFile(newPlayer, TextBoxEmail.Text.MakeFullFileName());
            GamePlay.Player = await FileHandler.LoadPlayerFromFile(TextBoxEmail.Text.MakeFullFileName());
            CheckLogin(GamePlay.Player);
        }

        private void CheckLogin(player playerResult)
        {
            if (playerResult.Email != null)
            {
                GamePlay.Player = playerResult;

                if (GamePlay.Player.Email != null)
                {
                    MunkWindow MunkWindow = new MunkWindow();
                    MunkWindow.Show();

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();

                    GameScoreCounter gameScoreCounter = new GameScoreCounter();
                    gameScoreCounter.CalculateSigninScore(GamePlay.Player);

                    LoadingWindow.Close();

                    this.Close();
                }
                else
                {
                    MessageBox.Show(GamePlay.Player.PlayerMessage);
                }
            }
        }

        private player CreateNewPlayer()
        {
            return new player()
            {
                Address = string.Empty,
                Email = TextBoxEmail.Text,
                FacebookAccessToken = string.Empty,
                FacebookDateOfBirth = string.Empty,
                FacebookEmail = string.Empty,
                FacebookFirstName = string.Empty,
                FacebookFullName = string.Empty,
                FacebookGender = string.Empty,
                FacebookId = string.Empty,
                FacebookLastName = string.Empty,
                FacebookPicture = string.Empty,
                Health = 72,
                HttpResult = string.Empty,
                LastDateMeditated = DateTime.Now,
                Level = Levels.Baby,
                ListDatesInRow = new List<DateTime>(),
                ListDatesInRowString = string.Empty,
                Multiplicator = 1,
                Password = TextBoxPassword.Password,
                PlayerMessage = string.Empty,
                Points = 1,
                TotalDaysMeditatedInRow = 1,
                TotalDaysMissed = 0,
                TotalHoursMissed = 0,
                TotalMinutesMeditated = 0,
                TotalMinutesMeditatedToday = 0
            };
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void LabelLoginWithFacebook_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }
    }
}
