using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisMatch;

namespace TennisMatchTests
{
    [TestClass]
    public class TennisMatchTests
    {
        [TestMethod]
        public void GetPlayersNameTest()
        {
            // arrange
            var match = new Match("Player1 Name", "Player2 Name");

            // asset
            Assert.AreEqual("Player1 Name", match.GetPlayer1Name());
            Assert.AreEqual("Player2 Name", match.GetPlayer2Name());
        }
    }
}
