using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedGame.GameLogic
{
    public class GameScoreCounter
    {
        public void CalculateSigninScore()
        {
            Game.Player.TotalDaysMissed = CalculateMissedDates();
            Game.Player.TotalHoursMissed = CalculateMissedHours();
            Game.Player.Multiplicator = (int)CalculateMultiplicator();      //Check punishment int/double
            Game.Player.Level = CheckLevel();
        }

        private int CalculateMissedDates()
        {
            int totalDaysMissed = (DateTime.Now.Date - Game.Player.LastDateMeditated.Date).Days;
            if (totalDaysMissed <= 0) return 0;

            return totalDaysMissed;
        }

        private int CalculateMissedHours()
        {
            int totalHoursMissed = (int)(DateTime.Now - Game.Player.LastDateMeditated).TotalHours;
            if (totalHoursMissed <= 0) return 0;

            return totalHoursMissed;
        }

        private double CalculateMultiplicator()
        {
            //Point punishment by reduced multiplicator
            double multiplicator = 0;

            if (Game.Player.TotalDaysMissed == 1)
            {
                multiplicator = (double)(Game.Player.Multiplicator * 0.080);
            }
            else if (Game.Player.TotalDaysMissed == 2)
            {
                multiplicator = (double)(Game.Player.Multiplicator * 0.50);
            }
            else
            {
                multiplicator = 1;
            }

            if (multiplicator == 0)
            {
                multiplicator = 1;
            }

            return multiplicator;
        }

        private string CheckLevel()
        {
            if (Game.Player.Points >= 0 && Game.Player.Points <= 10) { return "Baby"; }
            else if (Game.Player.Points >= 11 && Game.Player.Points <= 20) { return "Child"; }
            else if (Game.Player.Points >= 21 && Game.Player.Points <= 30) { return "Teenager"; }
            else if (Game.Player.Points >= 31 && Game.Player.Points <= 40) { return "Pupil"; }
            else if (Game.Player.Points >= 41 && Game.Player.Points <= 50) { return "YoungAdult"; }
            else if (Game.Player.Points >= 51 && Game.Player.Points <= 60) { return "Adult"; }
            else if (Game.Player.Points >= 61 && Game.Player.Points <= 70) { return "OldAdult"; }
            else if (Game.Player.Points >= 71 && Game.Player.Points <= 80) { return "Old"; }
            else if (Game.Player.Points >= 81 && Game.Player.Points <= 90) { return "Master"; }
            else if (Game.Player.Points >= 91 && Game.Player.Points <= 100) { return "Munk"; }
            else return "God";
        }
    }
}
