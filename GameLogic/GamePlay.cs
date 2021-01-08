using MedGame.Models;
using System;
using System.Windows.Threading;

namespace MedGame.GameLogic
{
    public class GamePlay
    {
        public static player Player = new player();

        public static DispatcherTimer MeditationTimer { get; set; } = new DispatcherTimer();

        public static void StartMeditation()
        {
            MeditationTimer = new DispatcherTimer();
            MeditationTimer.Interval = TimeSpan.FromSeconds(1);
            MeditationTimer.Tick += (object sender, EventArgs e) => { Player.TotalMinutesMeditatedToday++; };
            MeditationTimer.Start();
        }

        public static void StopMeditation()
        {
            MeditationTimer.Stop();

            if (CheckSameDate(DateTime.Now.Date))
            {
                GamePlay.Player = GameScoreCounter.CalculateMeditationScoreOnSameDay(Player, Player.TotalMinutesMeditatedToday);
            }
            else
            {
                GamePlay.Player = GameScoreCounter.CalculateMeditationScore(Player, Player.TotalMinutesMeditatedToday, Player.Multiplicator);
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
