using System;
using System.Threading.Tasks;
using MedGame.Models;
using MedGame.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedGame.ServicesProjectTest
{
    [TestClass]
    public class FileHandlerTests
    {
        [TestMethod]
        public async Task SavePlayerToFileShouldSavePlayer()
        {
            Player player = new Player();

            await FileHandler.SavePlayerToFile(player,"testuser");
            await FileHandler.RemoveUser("testUser");

        }

        [TestMethod]
        public async Task LoadPlayerFromFileShouldReturnPlayer()
        {
            Player player = new Player();

            await FileHandler.SavePlayerToFile(player, "testuser");
            var loadedPlayer = await FileHandler.LoadPlayerFromFile("testuser");
            await FileHandler.RemoveUser("testuser");

            Assert.IsNotNull(loadedPlayer);
        }


        [TestMethod]
        public async Task RemoveUserShouldRemoveUser()
        {
            Player player = new Player();

            await FileHandler.SavePlayerToFile(player, "testuser");
            var removedPlayer = await FileHandler.RemoveUser("testuser");

            Assert.IsTrue(removedPlayer);
        }
        public void GetFullFileNamePathShouldReturnPath()
        {
            var path = FileHandler.GetFullFileNamePath("test");

            Assert.IsNotNull(path);
        }
    }
}
