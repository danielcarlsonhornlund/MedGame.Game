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
                "TotalMinutesMeditatedToday: " + Game.Player.TotalMinutesMeditatedToday.ToString() + "\n" +
                "Health: " + Game.Player.Health.ToString() + "\n" +
                "Level: " + Game.Player.Level.ToString() + "\n" +
                "LastDateMeditated: " + Game.Player.LastDateMeditated.ToString() + "\n" +
                "Multiplicator: " + Game.Player.Multiplicator.ToString() + "\n" +
                "Password: " + Game.Player.Password.ToString() + "\n" +
                "Points: " + Game.Player.Points.ToString() + "\n" +
                "TotalDaysMeditatedInRow: " + Game.Player.TotalDaysMeditatedInRow.ToString() + "\n" +
                "TotalDaysMissed: " + Game.Player.TotalDaysMissed.ToString() + "\n" +
                "TotalMinutesMeditated: " + Game.Player.TotalMinutesMeditated.ToString() + "\n" +
                "UserName: " + Game.Player.UserName.ToString() + "\n" +
                "TotalHoursMissed: " + Game.Player.TotalHoursMissed + "\n" +
                "Email: " + Game.Player.Email.ToString();
            }
            catch (System.Exception) { }
        }
    }
}