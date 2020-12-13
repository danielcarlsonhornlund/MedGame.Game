using System;
using System.Threading.Tasks;
using MedGame.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedGame.Tests.GameLogicProject
{
 //   [TestClass]
    public class SignInTESTS
    {
        [TestMethod]
        public async Task SignInTEST()
        {
            RESTClient RESTClient = new RESTClient();
            Models.Player playerSignInResult = await RESTClient.SignIn("daniel", "daniel");
            Assert.AreNotEqual(null, playerSignInResult);
        }

        [TestMethod]
        public async Task SignUpTEST()
        {
            RESTClient RESTClient = new RESTClient();

            Models.Player playerSignInResult = await RESTClient.SignUp("daniel1", "daniel");

            Assert.AreNotEqual(null, playerSignInResult);
        }
    }
}
