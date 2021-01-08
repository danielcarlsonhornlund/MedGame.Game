using MedGame.Models;
using System;

namespace MedGame.GameLogic
{
    public class GameScoreCounter
    {
        public Player CalculateSigninScore(Player player)
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

        public static Player CalculateMeditationScore(Player player, int totalMinutesMeditatedNow, double multiplicator)
        {
            player.LastDateMeditated = DateTime.Now;
            player.TotalMinutesMeditatedToday += totalMinutesMeditatedNow;
            player.TotalMinutesMeditated += totalMinutesMeditatedNow;
            player.Multiplicator++;
            player.Points += (int)(totalMinutesMeditatedNow * multiplicator);
            player.TotalMinutesMeditatedNow = 0;

            return player;
        }

        public static Player CalculateMeditationScoreOnSameDay(Player player, int TotalMinutesMeditatedNow)
        {
            player.LastDateMeditated = DateTime.Now;
            player.TotalMinutesMeditatedToday += TotalMinutesMeditatedNow;
            player.TotalMinutesMeditated += TotalMinutesMeditatedNow;
            player.Points += TotalMinutesMeditatedNow;
            player.TotalMinutesMeditatedNow = 0;

            return player;
        }
    }
}
