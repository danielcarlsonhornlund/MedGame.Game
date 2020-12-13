using MedGame.GameLogic;
using MedGame.Models;
using MedGame.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            LoadingWindow.Show();

            //Player result = await RestClient.SignIn(TextBoxEmail.Text, TextBoxPassword.Password);

            Player player = new Player()
            {
                Email = "info@danielcarlson.net",
                Health = 100,
                Level = Levels.Baby,
                Points = 1,
                LastDateMeditated = new DateTime(2020, 02, 02),
                Multiplicator = 1,
                UserName = "Daniel",
                TotalDaysMeditatedInRow = 1,
                TotalDaysMissed = 0,
                TotalHoursMissed = 0,
                TotalMinutesMeditated = 100,
                TotalMinutesMeditatedToday = 1,
                ListDatesInRowString = "",
                ListDatesInRow = new List<DateTime>(),

            };

            CheckLogin(player);
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

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();

                    GameScoreCounter gameScoreCounter = new GameScoreCounter();
                    gameScoreCounter.CalculateSigninScore(Game.Player);

                    LoadingWindow.Close();

                    this.Close();
                }
                else
                {
                    MessageBox.Show(Game.Player.PlayerMessage);
                }
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void LabelLoginWithFacebook_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }
    }
}
