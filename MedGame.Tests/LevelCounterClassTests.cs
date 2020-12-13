using MedGame.GameLogic;
using MedGame.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedGame.GameLogicProject
{
    [TestClass]
    public class LevelCounterClassTests
    {
        [TestMethod]
        public void CheckLevelShouldReturnBaby()
        {
            Levels Level = LevelCounter.CheckLevel(5);
            Assert.AreEqual(Levels.Baby, Level);
        }

        [TestMethod]
        public void CheckLevelShouldReturnChild()
        {
            Levels Level = LevelCounter.CheckLevel(11);
            Assert.AreEqual(Levels.Child, Level);
        }

        [TestMethod]
        public void CheckLevelShouldReturnTeenager()
        {
            Levels Level = LevelCounter.CheckLevel(24);
            Assert.AreEqual(Levels.Teenager, Level);
        }

        [TestMethod]
        public void CheckLevelShouldReturnPupil()
        {
            Levels Level = LevelCounter.CheckLevel(36);
            Assert.AreEqual(Levels.Pupil, Level);
        }

        [TestMethod]
        public void CheckLevelShouldReturnYoungAdult()
        {
            Levels Level = LevelCounter.CheckLevel(47);
            Assert.AreEqual(Levels.YoungAdult, Level);
        }

        [TestMethod]
        public void CheckLevelShouldReturnAdult()
        {
            Levels Level = LevelCounter.CheckLevel(55);
            Assert.AreEqual(Levels.Adult, Level);
        }

        [TestMethod]
        public void CheckLevelShouldReturnOldAdult()
        {
            Levels Level = LevelCounter.CheckLevel(67);
            Assert.AreEqual(Levels.OldAdult, Level);
        }

        [TestMethod]
        public void CheckLevelShouldReturnOld()
        {
            Levels Level = LevelCounter.CheckLevel(75);
            Assert.AreEqual(Levels.Old, Level);
        }

        [TestMethod]
        public void CheckLevelShouldReturnMaster()
        {
            Levels Level = LevelCounter.CheckLevel(88);
            Assert.AreEqual(Levels.Master, Level);
        }

        [TestMethod]
        public void CheckLevelShouldReturnMunk()
        {
            Levels Level = LevelCounter.CheckLevel(100);
            Assert.AreEqual(Levels.Munk, Level);
        }


        [TestMethod]
        public void CheckLevelShouldReturnGod()
        {
            Levels Level = LevelCounter.CheckLevel(200);
            Assert.AreEqual(Levels.God, Level);
        }
    }
}
