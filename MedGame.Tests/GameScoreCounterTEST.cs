using System;
using MedGame.GameLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedGame.Tests
{
    [TestClass]
    public class GameScoreCounterTEST
    {
        [TestMethod]
        public void CalculateMissedDatesTEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();

            int days = gameScoreCounter.CalculateMissedDates(new DateTime(2019, 01, 14));

            Assert.AreEqual(2, days);
        }

        [TestMethod]
        public void CalculateMissedHoursTEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();

            int hours = gameScoreCounter.CalculateMissedHours(new DateTime(2019, 01, 14));

            Assert.AreEqual(60, hours);
        }

        [TestMethod]
        public void CalculateMultiplicatorTEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();

            int totalDaysMissed = gameScoreCounter.CalculateMissedDates(new DateTime(2019, 01, 15));

            double multiplicator = gameScoreCounter.CalculateMultiplicator(totalDaysMissed, 20);
            Assert.AreEqual(10, multiplicator);
        }

        [TestMethod]
        public void CheckLevelTEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();
            string Level = gameScoreCounter.CheckLevel(1568);
            Assert.AreEqual("God",Level);
        }
    }
}
