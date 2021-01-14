using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisMatch;

namespace TennisMatchTests
{
    [TestClass]
    public class TennisMatchTests
    {
        /// <summary>
        /// Method to check that the match player names are well managed
        /// </summary>
        [TestMethod]
        public void GetPlayersNameTest()
        {
            // arrange
            var match = new Match("Player1 Name", "Player2 Name");

            // assert
            Assert.AreEqual("Player1 Name", match.GetPlayerName(PlayerOrder.player1));
            Assert.AreEqual("Player2 Name", match.GetPlayerName(PlayerOrder.player2));
            Assert.AreNotEqual("Player1", match.GetPlayerName(PlayerOrder.player1));
            Assert.AreNotEqual("Player2", match.GetPlayerName(PlayerOrder.player2));
        }

        /// <summary>
        /// Method to check if the game scores works as expected with tennis values
        /// </summary>
        [TestMethod]
        public void PlayersGameScoresTest()
        {
            // arrange
            var match = new Match("Player1 Name", "Player2 Name");

            // assert
            Assert.AreEqual("0", match.GetPlayerGameScore(PlayerOrder.player1));
            Assert.AreEqual("0", match.GetPlayerGameScore(PlayerOrder.player2));
        }
    }
}
