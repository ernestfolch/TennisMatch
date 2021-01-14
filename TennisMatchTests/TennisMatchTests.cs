using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisMatch;

namespace TennisMatchTests
{
    [TestClass]
    public class TennisMatchTests
    {
        /// <summary>
        /// Unit test to check that the match player names are well managed
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
        /// Unit test to check if the game scores works as expected with tennis values
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

        /// <summary>
        /// Unit test to check if the add points to player works
        /// </summary>
        [TestMethod]
        public void AddPlayersPointsTest()
        {
            // arrange
            var match = new Match("Player1 Name", "Player2 Name");

            // act
            match.AddPlayerPoint(PlayerOrder.player1); // Add one point to the player1

            // assert
            Assert.AreEqual("15", match.GetPlayerGameScore(PlayerOrder.player1));
            Assert.AreEqual("0", match.GetPlayerGameScore(PlayerOrder.player2));
        }
    }
}
