using MedGame.Models;
using System;
using System.Collections.Generic;

namespace MedGame.Tests
{
    public class TestBase
    {
        public static Player player = new Player()
        {
            Email = "info@danielcarlson.net",
            Health = 100,
            Level = Levels.Baby,
            Points = 100,
            LastDateMeditated = DateTime.Now.AddDays(-1),
            Multiplicator = 1,
            TotalDaysMeditatedInRow = 1,
            TotalDaysMissed = 0,
            TotalHoursMissed = 0,
            TotalMinutesMeditated = 100,
            TotalMinutesMeditatedToday = 1,
            ListDatesInRowString = "",
            ListDatesInRow = new List<DateTime>(),
        };
    }
}
