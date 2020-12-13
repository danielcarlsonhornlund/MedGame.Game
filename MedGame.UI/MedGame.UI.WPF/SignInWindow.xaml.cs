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

            GamePlay.Player = await FileHandler.LoadPlayerFromFile(TextBoxEmail.Text);

            CheckLogin(GamePlay.Player);
        }

        private async void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        {
            //Player result = await RestClient.SignUp(TextBoxEmail.Text, TextBoxPassword.Password);
            await FileHandler.SavePlayerToFile(new Player(), TextBoxEmail.Text);
            GamePlay.Player = await FileHandler.LoadPlayerFromFile(TextBoxEmail.Text);
            CheckLogin(GamePlay.Player);
        }

        private void CheckLogin(Player playerResult)
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


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void LabelLoginWithFacebook_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }
    }
}
