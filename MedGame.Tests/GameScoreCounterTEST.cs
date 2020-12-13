using System;
using MedGame.GameLogic;
using MedGame.Models;
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

            int days = gameScoreCounter.CalculateMissedDates(new DateTime(2019, 01, 14), new DateTime(2019, 01, 16));

            Assert.AreEqual(2, days);
        }

        [TestMethod]
        public void CalculateMissedHoursTEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();

            int hours = gameScoreCounter.CalculateMissedHours(new DateTime(2019, 01, 12), new DateTime(2019, 01, 14));

            Assert.AreEqual(48, hours);
        }

        [TestMethod]
        public void CalculateMultiplicatorMissedOneDayTEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();

            int totalDaysMissed = gameScoreCounter.CalculateMissedDates(new DateTime(2019, 01, 15), new DateTime(2019, 01, 16));

            double multiplicator = gameScoreCounter.CalculateMultiplicator(totalDaysMissed, 365);
            Assert.AreEqual(292, multiplicator);
        }


        [TestMethod]
        public void CalculateMultiplicatorMissedTwoDaysShouldPunishWithHalfMultiplicatorPointsTEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();

            int totalDaysMissed = gameScoreCounter.CalculateMissedDates(new DateTime(2019, 01, 15), new DateTime(2019, 01, 17));
            double multiplicator = gameScoreCounter.CalculateMultiplicator(totalDaysMissed, 365);
            Assert.AreEqual(182.5, multiplicator);
        }

        [TestMethod]
        public void CalculateMultiplicatorMissedMoreThanTwoDaysShouldResetMultiplicatorTo1TEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();

            int totalDaysMissed = gameScoreCounter.CalculateMissedDates(new DateTime(2019, 01, 15), new DateTime(2019, 01, 18));
            double multiplicator = gameScoreCounter.CalculateMultiplicator(totalDaysMissed, 365);
            Assert.AreEqual(1, multiplicator);
        }

        [TestMethod]
        public void CheckBabyLevelTEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();
            Levels Level = gameScoreCounter.CheckLevel(5);
            Assert.AreEqual(Levels.Baby, Level);
        }

        [TestMethod]
        public void CheckChildLevelTEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();
            Levels Level = gameScoreCounter.CheckLevel(11);
            Assert.AreEqual(Levels.Child, Level);
        }

        [TestMethod]
        public void CheckTeenagerLevelTEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();
            Levels Level = gameScoreCounter.CheckLevel(24);
            Assert.AreEqual(Levels.Teenager, Level);
        }

        [TestMethod]
        public void CheckPupilLevelTEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();
            Levels Level = gameScoreCounter.CheckLevel(36);
            Assert.AreEqual(Levels.Pupil, Level);
        }

        [TestMethod]
        public void CheckYoungAdultLevelTEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();
            Levels Level = gameScoreCounter.CheckLevel(47);
            Assert.AreEqual(Levels.YoungAdult, Level);
        }

        [TestMethod]
        public void CheckAdultLevelTEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();
            Levels Level = gameScoreCounter.CheckLevel(55);
            Assert.AreEqual(Levels.Adult, Level);
        }

        [TestMethod]
        public void CheckOldAdultLevelTEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();
            Levels Level = gameScoreCounter.CheckLevel(67);
            Assert.AreEqual(Levels.OldAdult, Level);
        }

        [TestMethod]
        public void CheckOldLevelTEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();
            Levels Level = gameScoreCounter.CheckLevel(75);
            Assert.AreEqual(Levels.Old, Level);
        }

        [TestMethod]
        public void CheckMasterLevelTEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();
            Levels Level = gameScoreCounter.CheckLevel(88);
            Assert.AreEqual(Levels.Master, Level);
        }

        [TestMethod]
        public void CheckMunkLevelTEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();
            Levels Level = gameScoreCounter.CheckLevel(100);
            Assert.AreEqual(Levels.Munk, Level);
        }


        [TestMethod]
        public void CheckGodLevelTEST()
        {
            GameScoreCounter gameScoreCounter = new GameScoreCounter();
            Levels Level = gameScoreCounter.CheckLevel(200);
            Assert.AreEqual(Levels.God, Level);
        }
    }
}
