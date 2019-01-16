using MedGame.Models;
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
            Game.Player.TotalDaysMissed = CalculateMissedDates(Game.Player.LastDateMeditated);
            Game.Player.TotalHoursMissed = CalculateMissedHours(Game.Player.LastDateMeditated);
            Game.Player.Multiplicator = (int)CalculateMultiplicator(Game.Player.TotalDaysMissed, Game.Player.Multiplicator);      //Check punishment int/double
            Game.Player.Level = CheckLevel(Game.Player.Points);
        }

        public int CalculateMissedDates(DateTime LastDateMeditated)
        {
            int totalDaysMissed = (DateTime.Now.Date - LastDateMeditated.Date).Days;
            if (totalDaysMissed <= 0) return 0;

            return totalDaysMissed;
        }

        public int CalculateMissedHours(DateTime LastDateMeditated)
        {
            int totalHoursMissed = (int)(DateTime.Now - LastDateMeditated).TotalHours;
            if (totalHoursMissed <= 0) return 0;

            return totalHoursMissed;
        }

        public double CalculateMultiplicator(int totalDaysMieesd, int multiplicator)
        {
            //Point punishment by reduced multiplicator
            double multiplicatorTemp = 0;

            if (totalDaysMieesd == 1)
            {
                multiplicatorTemp = (double)(multiplicator * 0.80);
            }
            else if (totalDaysMieesd == 2)
            {
                multiplicatorTemp = (double)(multiplicator * 0.50);
            }
            else
            {
                multiplicatorTemp = 1;
            }

            if (multiplicatorTemp == 0)
            {
                multiplicatorTemp = 1;
            }

            return multiplicatorTemp;
        }

        public string CheckLevel(int playerPoints)
        {
            if (playerPoints >= 0 && playerPoints <= 10) { return "Baby"; }
            else if (playerPoints >= 11 && playerPoints <= 20) { return "Child"; }
            else if (playerPoints >= 21 && playerPoints <= 30) { return "Teenager"; }
            else if (playerPoints >= 31 && playerPoints <= 40) { return "Pupil"; }
            else if (playerPoints >= 41 && playerPoints <= 50) { return "YoungAdult"; }
            else if (playerPoints >= 51 && playerPoints <= 60) { return "Adult"; }
            else if (playerPoints >= 61 && playerPoints <= 70) { return "OldAdult"; }
            else if (playerPoints >= 71 && playerPoints <= 80) { return "Old"; }
            else if (playerPoints >= 81 && playerPoints <= 90) { return "Master"; }
            else if (playerPoints >= 91 && playerPoints <= 100) { return "Munk"; }
            else return "God";
        }
    }
}
