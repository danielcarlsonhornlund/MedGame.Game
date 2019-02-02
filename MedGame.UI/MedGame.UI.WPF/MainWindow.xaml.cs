using MedGame.GameLogic;
using MedGame.Models;
using MedGame.Services;
using System;
using System.Windows;
using System.Windows.Threading;

namespace MedGame.UI.WPF
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            SetLabel();
            UpdateUI();

            timer.Interval= TimeSpan.FromSeconds(1);

            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            UpdateUI();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            FileHandler.LoadFromFile();
            UpdateUI();
        }

        private async void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            RESTClient RESTClient = new RESTClient();
            await RESTClient.Update(Game.Player);
            UpdateUI();
        }

        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {

            if (ButtonPlay.Content.Equals("Play"))
            {
                ButtonPlay.Content = "Stop";
                Game.StartMeditation();
            }
            else
            {
                ButtonPlay.Content = "Play";
                Game.StopMeditation();
                UpdateUI();
            }
        }

        public void UpdateUI()
        {
            try
            {
                LabelPlayer.Content =
                Game.Player.TotalMinutesMeditatedToday.ToString() + "\n" +
                Game.Player.Health.ToString() + "\n" +
                Game.Player.Level.ToString() + "\n" +
                Game.Player.LastDateMeditated.ToString() + "\n" +
                Game.Player.Multiplicator.ToString() + "\n" +
                Game.Player.Password.ToString() + "\n" +
                Game.Player.Points.ToString() + "\n" +
                Game.Player.TotalDaysMeditatedInRow.ToString() + "\n" +
                Game.Player.TotalDaysMissed.ToString() + "\n" +
                Game.Player.TotalMinutesMeditated.ToString() + "\n" +
                Game.Player.UserName.ToString() + "\n" +
                Game.Player.Email.ToString();

            }
            catch (System.Exception)
            {
                
            }
            

        }

        private void SetLabel()
        {

            try
            {
                LabelPlayerInfo.Content =
             "Total Minutes meditated today: \n" +
             "Health: \n" +
             "Level: \n" +
             "Last Date Meditated: \n" +
             "Multiplicator: \n" +
             "Password: \n" +
             "Points: \n" +
             "Total Days Meditated In Row: \n" +
             "Total Days Missed: \n" +
             "Total Minutes meditated: \n" +
             "Username: \n" +
             "Email: ";
            }
            catch (System.Exception)
            {
                
            }
         

        }

    }
}
