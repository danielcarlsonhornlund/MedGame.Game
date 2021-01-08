using MedGame.Models;
using System;

namespace MedGame.GameLogic
{
    public class GameScoreCounter
    {
        public player CalculateSigninScore(player player)
        {
            player.TotalDaysMissed = CalculateMissedDates(player.LastDateMeditated.Date, DateTime.Now.Date);
            player.TotalHoursMissed = CalculateMissedHours(DateTime.Now, player.LastDateMeditated);
            player.Multiplicator = MultiplicatorCounter.CalculateMultiplicator(player.TotalDaysMissed, player.Multiplicator);      //Check punishment int/double
            player.Level = LevelCounter.CheckLevel(player.Points);

            return player;
        }

        public int CalculateMissedDates(DateTime LastDateMeditated, DateTime todaysDate)
        {
            int totalDaysMissed = (todaysDate - LastDateMeditated).Days;
            if (totalDaysMissed <= 0) return 0;

            return totalDaysMissed;
        }

        public int CalculateMissedHours(DateTime LastDateMeditated, DateTime currentHour)
        {
            int totalHoursMissed = (int)(currentHour - LastDateMeditated).TotalHours;
            if (totalHoursMissed <= 0) return 0;

            return totalHoursMissed;
        }

        public static player CalculateMeditationScore(player player, int totalMinutesMeditatedToday, double multiplicator)
        {
            player.LastDateMeditated = DateTime.Now;
            player.TotalMinutesMeditated += totalMinutesMeditatedToday;
            player.Multiplicator++;
            player.Points += (int)(totalMinutesMeditatedToday * multiplicator);
            player.TotalMinutesMeditatedToday = 0;

            return player;
        }

        public static player CalculateMeditationScoreOnSameDay(player player, int TotalMinutesMeditatedToday)
        {
            player.LastDateMeditated = DateTime.Now;
            player.TotalMinutesMeditated += TotalMinutesMeditatedToday;
            player.Points += TotalMinutesMeditatedToday;

            return player;
        }
    }
}
