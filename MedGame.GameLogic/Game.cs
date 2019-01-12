using MedGame.Models;
using System;
using System.Windows.Threading;

namespace MedGame.GameLogic
{
    public class Game
    {
        public static Player Player = new Player();

        private static DispatcherTimer MeditationTimer { get; set; }

        private static void CalculateMissedDates()
        {
            int totalDaysMissedInRow = (DateTime.Now - Player.LastDateMeditated).Days;
            Player.TotalDaysMissed = totalDaysMissedInRow;
        }

        private static void CheckDates()
        {
            if (Player.ListDatesInRow.Count >= 3)// && !CheckSameDate())
            {
                Player.TotalDaysMeditatedInRow++;
                CalculateMissedDates();
                CalculateMultiplicator();
                Player.LastDateMeditated = DateTime.Now;
            }
        }

        private static void CalculateMultiplicator()
        {
            int multiplicator = Player.TotalDaysMissed;

            if (multiplicator == 1) Player.Multiplicator = Player.Multiplicator - 1;
            else if (multiplicator == 2) Player.Multiplicator = Player.Multiplicator - 3;
            else if (multiplicator >= 3) Player.Multiplicator = 1;

            else Player.Multiplicator = Player.Multiplicator + 1;

            if (Player.Multiplicator <= 0)
            {
                Player.Multiplicator = 1;
            }
        }

        private static void CheckLevel()
        {
            if (Player.Points >= 0 && Player.Points <= 10) { Player.Level = "Baby"; }
            else if (Player.Points >= 11 && Player.Points <= 20) { Player.Level = "Child"; }
            else if (Player.Points >= 21 && Player.Points <= 30) { Player.Level = "Teenager"; }
            else if (Player.Points >= 31 && Player.Points <= 40) { Player.Level = "Pupil"; }
            else if (Player.Points >= 41 && Player.Points <= 50) { Player.Level = "YoungAdult"; }
            else if (Player.Points >= 51 && Player.Points <= 60) { Player.Level = "Adult"; }
            else if (Player.Points >= 61 && Player.Points <= 70) { Player.Level = "OldAdult"; }
            else if (Player.Points >= 71 && Player.Points <= 80) { Player.Level = "Old"; }
            else if (Player.Points >= 81 && Player.Points <= 90) { Player.Level = "Master"; }
            else if (Player.Points >= 91 && Player.Points <= 100) { Player.Level = "Munk"; }
            else Player.Level = "God";
        }


        public static void StartMeditation()
        {
            MeditationTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(1000)
            };

            MeditationTimer.Tick += CalculateMeditation;

            MeditationTimer.Start();
        }

        private static void CalculateMeditation(object sender, EventArgs e)
        {
            Game.Player.TotalMinutesMeditatedToday++;
            Game.Player.Points = Game.Player.TotalMinutesMeditatedToday * Game.Player.Multiplicator;
            Game.CheckLevel();
        }

        public static void StopMeditation()
        {
            MeditationTimer.Stop();
        }

        private static bool CheckSameDate()
        {
            if (Game.Player.LastDateMeditated.Date == DateTime.Now.Date)
            {
                return true;
            }
            return false;
        }

        private static void StopGame()
        {
            Game.Player.TotalMinutesMeditated = Game.Player.TotalMinutesMeditated + Game.Player.TotalMinutesMeditatedToday;
        }
    }
}
