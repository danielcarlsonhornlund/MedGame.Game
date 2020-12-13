using System;
using MedGame.GameLogic;
using MedGame.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedGame.GameLogicProject
{
    [TestClass]
    public class MultiplicatorCounterClassTests
    {
        [TestMethod]
        public void CalculateMissedDatesShouldReturn2()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();

            int days = gameScoreCounter.CalculateMissedDates(new DateTime(2019, 01, 14), new DateTime(2019, 01, 16));

            Assert.AreEqual(2, days);
        }

        [TestMethod]
        public void CalculateMissedHoursShouldReturn48()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();

            int hours = gameScoreCounter.CalculateMissedHours(new DateTime(2019, 01, 12), new DateTime(2019, 01, 14));

            Assert.AreEqual(48, hours);
        }
    }
}
