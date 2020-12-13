using MedGame.Models;
using System;

namespace MedGame.GameLogic
{
    public class GameScoreCounter
    {
        public void CalculateSigninScore()
        {
            Game.Player.TotalDaysMissed = CalculateMissedDates(Game.Player.LastDateMeditated, DateTime.Now.Date);
            Game.Player.TotalHoursMissed = CalculateMissedHours(DateTime.Now, Game.Player.LastDateMeditated);
            Game.Player.Multiplicator = (int)CalculateMultiplicator(Game.Player.TotalDaysMissed, Game.Player.Multiplicator);      //Check punishment int/double
            Game.Player.Level = CheckLevel(Game.Player.Points);
        }

        public int CalculateMissedDates(DateTime LastDateMeditated, DateTime todaysDate)
        {
            int totalDaysMissed = (todaysDate.Date - LastDateMeditated.Date).Days;
            if (totalDaysMissed <= 0) return 0;

            return totalDaysMissed;
        }

        public int CalculateMissedHours(DateTime LastDateMeditated, DateTime currentHour)
        {
            int totalHoursMissed = (int)(currentHour - LastDateMeditated).TotalHours;
            if (totalHoursMissed <= 0) return 0;

            return totalHoursMissed;
        }

        public double CalculateMultiplicator(int totalDaysMieesd, int currentMultiplicatorPoints)
        {
            //Point punishment by reduced multiplicator
            double multiplicatorTemp;
            if (totalDaysMieesd == 1) { multiplicatorTemp = (double)(currentMultiplicatorPoints * 0.80); }
            else if (totalDaysMieesd == 2) { multiplicatorTemp = (double)(currentMultiplicatorPoints * 0.50); }
            else { multiplicatorTemp = 1; }
            if (multiplicatorTemp == 0) { multiplicatorTemp = 1; }
            return multiplicatorTemp;
        }

        public Levels CheckLevel(int playerPoints)
        {
            if (playerPoints >= 0 && playerPoints <= 10) { return Levels.Baby; }
            else if (playerPoints >= 11 && playerPoints <= 20) { return Levels.Child; }
            else if (playerPoints >= 21 && playerPoints <= 30) { return Levels.Teenager; }
            else if (playerPoints >= 31 && playerPoints <= 40) { return Levels.Pupil; }
            else if (playerPoints >= 41 && playerPoints <= 50) { return Levels.YoungAdult; }
            else if (playerPoints >= 51 && playerPoints <= 60) { return Levels.Adult; }
            else if (playerPoints >= 61 && playerPoints <= 70) { return Levels.OldAdult; }
            else if (playerPoints >= 71 && playerPoints <= 80) { return Levels.Old; }
            else if (playerPoints >= 81 && playerPoints <= 90) { return Levels.Master; }
            else if (playerPoints >= 91 && playerPoints <= 100) { return Levels.Munk; }
            else return Levels.God;
        }
    }
}
