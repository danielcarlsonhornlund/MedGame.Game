using System;
using MedGame.GameLogic;
using MedGame.Models;
using MedGame.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedGame.GameLogicProject
{
    [TestClass]
    public class GameClassTests : TestBase
    {
        [TestMethod]
        public void StartMeditationShouldStartTimer()
        {
            Game.StartMeditation();
            Assert.IsTrue(Game.MeditationTimer.IsEnabled);
        }

        [TestMethod]
        public void StopMeditationShouldStopTimer()
        {
            Game.StartMeditation();
            Game.StopMeditation(player);
            Assert.IsFalse(Game.MeditationTimer.IsEnabled);
        }

        [TestMethod]
        public void CheckSameDateShouldReturnTrue()
        {
            player.LastDateMeditated = DateTime.Now.Date;
            var isSameDate = Game.CheckSameDate(DateTime.Now.Date);
            Assert.IsTrue(isSameDate);
        }

        [TestMethod]
        public void CheckSameDateShouldReturnFalse()
        {
            player.LastDateMeditated = DateTime.Now.Date.AddDays(1);
            var isSameDate = Game.CheckSameDate(player.LastDateMeditated);
            Assert.IsFalse(isSameDate);
        }
    }
}
