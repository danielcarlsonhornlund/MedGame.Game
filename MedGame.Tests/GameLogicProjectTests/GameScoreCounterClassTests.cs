using MedGame.GameLogic;
using MedGame.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MedGame.GameLogicProject
{
    [TestClass]
    public class GameScoreCounterClassTests : TestBase
    {
        [TestMethod]
        public void CalculateSigninScoreShouldUpdatePlayer()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();
            var player = gameScoreCounter.CalculateSigninScore(TestBase.player);
            Assert.IsNotNull(player);
        }

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
