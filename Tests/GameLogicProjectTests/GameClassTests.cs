using MedGame.GameLogic;
using MedGame.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MedGame.GameLogicProject
{
    [TestClass]
    public class GameClassTests : TestBase
    {
        [TestMethod]
        public void StartMeditationShouldStartTimer()
        {
            GamePlay.StartMeditation();
            Assert.IsTrue(GamePlay.MeditationTimer.IsEnabled);
        }

        [TestMethod]
        public void StopMeditationShouldStopTimer()
        {
            GamePlay.StartMeditation();
            GamePlay.StopMeditation();
            Assert.IsFalse(GamePlay.MeditationTimer.IsEnabled);
        }

        [TestMethod]
        public void CheckSameDateShouldReturnTrue()
        {
            player.LastDateMeditated = DateTime.Now.Date;
            var isSameDate = GamePlay.CheckSameDate(DateTime.Now.Date);
            Assert.IsTrue(isSameDate);
        }

        [TestMethod]
        public void CheckSameDateShouldReturnFalse()
        {
            player.LastDateMeditated = DateTime.Now.Date.AddDays(1);
            var isSameDate = GamePlay.CheckSameDate(player.LastDateMeditated);
            Assert.IsFalse(isSameDate);
        }
    }
}
