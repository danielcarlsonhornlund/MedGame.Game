using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedGame.GameLogic
{
    public static class GameScoreCounter
    {
        public static int CalculateMissedDates()
        {
            int totalDaysMissed = (DateTime.Now - Game.Player.LastDateMeditated).Days;
            return totalDaysMissed;
        }

        public static int CalculateMissedHours()
        {
            int totalHoursMissed = (int)(DateTime.Now - Game.Player.LastDateMeditated).TotalHours;
            return totalHoursMissed;
        }

        private static void CalculateMeditation(object sender, EventArgs e)
        {
            Game.Player.TotalMinutesMeditatedToday++;
            Game.Player.Points = Game.Player.TotalMinutesMeditatedToday * Game.Player.Multiplicator;
        }


        public static void CalculateMultiplicator()
        {
            //Point punishment by reduced multiplicator
            
            if (Game.Player.TotalDaysMissed == 1) Game.Player.Multiplicator = (int)(Game.Player.Multiplicator * 0.080);
            else if (Game.Player.TotalDaysMissed == 2) Game.Player.Multiplicator = (int)(Game.Player.Multiplicator * 0.50);
            else if (Game.Player.TotalDaysMissed >= 3) Game.Player.Multiplicator = 1;

            else Game.Player.Multiplicator = Game.Player.Multiplicator + 1;

            if (Game.Player.Multiplicator <= 0)
            {
                Game.Player.Multiplicator = 1;
            }
        }

        public static void CheckLevel()
        {
            if (Game.Player.Points >= 0 && Game.Player.Points <= 10) { Game.Player.Level = "Baby"; }
            else if (Game.Player.Points >= 11 && Game.Player.Points <= 20) { Game.Player.Level = "Child"; }
            else if (Game.Player.Points >= 21 && Game.Player.Points <= 30) { Game.Player.Level = "Teenager"; }
            else if (Game.Player.Points >= 31 && Game.Player.Points <= 40) { Game.Player.Level = "Pupil"; }
            else if (Game.Player.Points >= 41 && Game.Player.Points <= 50) { Game.Player.Level = "YoungAdult"; }
            else if (Game.Player.Points >= 51 && Game.Player.Points <= 60) { Game.Player.Level = "Adult"; }
            else if (Game.Player.Points >= 61 && Game.Player.Points <= 70) { Game.Player.Level = "OldAdult"; }
            else if (Game.Player.Points >= 71 && Game.Player.Points <= 80) { Game.Player.Level = "Old"; }
            else if (Game.Player.Points >= 81 && Game.Player.Points <= 90) { Game.Player.Level = "Master"; }
            else if (Game.Player.Points >= 91 && Game.Player.Points <= 100) { Game.Player.Level = "Munk"; }
            else Game.Player.Level = "God";
        }

    }
}
