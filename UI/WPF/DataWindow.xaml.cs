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
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (object sender, EventArgs e) => { UpdateUI(); };
            timer.Start();
            InitializeComponent();

        }

        public void UpdateUI()
        {
            try
            {
                LabelPlayer.Content =
                "TotalMinutesMeditatedToday: " + GamePlay.Player.TotalMinutesMeditatedToday.ToString() + "\n" +
                "Health: " + GamePlay.Player.Health.ToString() + "\n" +
                "Level: " + GamePlay.Player.Level.ToString() + "\n" +
                "LastDateMeditated: " + GamePlay.Player.LastDateMeditated.ToString() + "\n" +
                "Multiplicator: " + GamePlay.Player.Multiplicator.ToString() + "\n" +
                "Password: " + GamePlay.Player.Password.ToString() + "\n" +
                "Points: " + GamePlay.Player.Points.ToString() + "\n" +
                "TotalDaysMeditatedInRow: " + GamePlay.Player.TotalDaysMeditatedInRow.ToString() + "\n" +
                "TotalDaysMissed: " + GamePlay.Player.TotalDaysMissed.ToString() + "\n" +
                "TotalMinutesMeditated: " + GamePlay.Player.TotalMinutesMeditated.ToString() + "\n" +
                "UserName: " + GamePlay.Player.UserName.ToString() + "\n" +
                "TotalHoursMissed: " + GamePlay.Player.TotalHoursMissed + "\n" +
                "Email: " + GamePlay.Player.Email.ToString();
            }
            catch (System.Exception) { }
        }
    }
}