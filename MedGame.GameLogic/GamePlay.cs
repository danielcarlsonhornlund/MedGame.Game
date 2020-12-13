using MedGame.Models;
using System;
using System.Windows.Threading;

namespace MedGame.GameLogic
{
    public class GamePlay
    {
        public static Player Player = new Player();

        public static DispatcherTimer MeditationTimer { get; set; } = new DispatcherTimer();

        public static void StartMeditation()
        {
            MeditationTimer = new DispatcherTimer();
            MeditationTimer.Interval = TimeSpan.FromSeconds(1);
            MeditationTimer.Tick += (object sender, EventArgs e) => { Player.TotalMinutesMeditatedToday++; };
            MeditationTimer.Start();
        }

        public static void StopMeditation(Player player)
        {
            MeditationTimer.Stop();

            if (CheckSameDate(DateTime.Now.Date))
            {
                Player.LastDateMeditated = DateTime.Now;
                Player.TotalMinutesMeditated += player.TotalMinutesMeditatedToday;
            }
            else
            {
                Player.LastDateMeditated = DateTime.Now;
                Player.TotalMinutesMeditated += Player.TotalMinutesMeditatedToday;
                Player.Points = Player.Points + (Player.TotalMinutesMeditatedToday * Player.Multiplicator);
                Player.TotalMinutesMeditatedToday = 0;
            }

           Player.TotalDaysMissed = 0;
           Player.TotalHoursMissed = 0;
        }



        public static bool CheckSameDate(DateTime todaysDate)
        {
            if (Player.LastDateMeditated.Date == todaysDate)
            {
                return true;
            }
            return false;
        }
    }
}
