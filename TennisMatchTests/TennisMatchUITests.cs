using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisMatch.UI.Model;
using TennisMatch.UI.ViewModel;

namespace TennisMatchTests
{
    [TestClass]
    public class TennisMatchUITests
    {
        /// <summary>
        /// Unit test to check the start if the shared match starts properly
        /// </summary>
        [TestMethod]
        public void StartMatchTest()
        {
            // arrange
            var sessionContext = new SessionContext();
            var refereePanelViewModel = new RefereePanelViewModel(sessionContext);
            var scoreboardViewModel = new ScoreboardViewModel(sessionContext);

            // act
            sessionContext.Player1Name = "Player1";
            sessionContext.Player2Name = "Player2";
            refereePanelViewModel.StartMatch(null);

            // assert
            Assert.AreEqual("Match Started!",
                            refereePanelViewModel.SessionContext.RefereeInfo);
            Assert.IsNotNull(refereePanelViewModel.SessionContext.Match);
            Assert.IsNotNull(scoreboardViewModel.SessionContext.Match);
            Assert.AreEqual("Player1", scoreboardViewModel.SessionContext.Player1Name);
            Assert.AreEqual("Player2", scoreboardViewModel.SessionContext.Player2Name);
            Assert.AreEqual("0", scoreboardViewModel.SessionContext.Player1GameScore);
            Assert.AreEqual("0", scoreboardViewModel.SessionContext.Player2GameScore);
            Assert.IsTrue(scoreboardViewModel.SessionContext.Player1Server);
            Assert.IsFalse(scoreboardViewModel.SessionContext.Player2Server);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player1WonGamesSet1);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player2WonGamesSet1);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player1WonGamesSet2);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player2WonGamesSet2);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player1WonGamesSet3);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player2WonGamesSet3);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player1WonGamesSet4);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player2WonGamesSet4);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player1WonGamesSet5);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player2WonGamesSet5);
        }

        /// <summary>
        /// Unit test to check the restart match when a current match is playing
        /// </summary>
        [TestMethod]
        public void RestartMatchTest()
        {
            // arrange
            var sessionContext = new SessionContext();
            var refereePanelViewModel = new RefereePanelViewModel(sessionContext);
            var scoreboardViewModel = new ScoreboardViewModel(sessionContext);

            // act
            sessionContext.Player1Name = "Player1";
            sessionContext.Player2Name = "Player2";
            refereePanelViewModel.StartMatch(null);
            refereePanelViewModel.AddPlayerPoint("Player1");
            refereePanelViewModel.StartMatch(null);

            // assert
            Assert.AreEqual("Match Restarted!",
                            refereePanelViewModel.SessionContext.RefereeInfo);
            Assert.IsNotNull(refereePanelViewModel.SessionContext.Match);
            Assert.IsNotNull(scoreboardViewModel.SessionContext.Match);
            Assert.AreEqual("Player1", scoreboardViewModel.SessionContext.Player1Name);
            Assert.AreEqual("Player2", scoreboardViewModel.SessionContext.Player2Name);
            Assert.AreEqual("0", scoreboardViewModel.SessionContext.Player1GameScore);
            Assert.AreEqual("0", scoreboardViewModel.SessionContext.Player2GameScore);
            Assert.IsTrue(scoreboardViewModel.SessionContext.Player1Server);
            Assert.IsFalse(scoreboardViewModel.SessionContext.Player2Server);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player1WonGamesSet1);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player2WonGamesSet1);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player1WonGamesSet2);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player2WonGamesSet2);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player1WonGamesSet3);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player2WonGamesSet3);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player1WonGamesSet4);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player2WonGamesSet4);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player1WonGamesSet5);
            Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player2WonGamesSet5);
        }

        /// <summary>
        /// Unit test to check the message when a match is started without defining players
        /// </summary>
        [TestMethod]
        public void StartMatchWithoutPlayersTest()
        {
            // arrange
            var sessionContext = new SessionContext();
            var refereePanelViewModel = new RefereePanelViewModel(sessionContext);
            var scoreboardViewModel = new ScoreboardViewModel(sessionContext);

            // act
            refereePanelViewModel.StartMatch(null);

            // assert
            Assert.AreEqual("You need to define the players names",
                           refereePanelViewModel.SessionContext.RefereeInfo);
            Assert.IsNull(refereePanelViewModel.SessionContext.Match);
            Assert.IsNull(scoreboardViewModel.SessionContext.Match);
        }

        /// <summary>
        /// Unit test to check the message when a point is added without without starting a match
        /// </summary>
        [TestMethod]
        public void AddPointWithoutMatchTest()
        {
            // arrange
            var sessionContext = new SessionContext();
            var refereePanelViewModel = new RefereePanelViewModel(sessionContext);
            var scoreboardViewModel = new ScoreboardViewModel(sessionContext);

            // act
            refereePanelViewModel.AddPlayerPoint("Player1");

            // assert
            Assert.AreEqual("You need to start the match first",
                            refereePanelViewModel.SessionContext.RefereeInfo);
            Assert.IsNull(refereePanelViewModel.SessionContext.Match);
            Assert.IsNull(scoreboardViewModel.SessionContext.Match);
        }

        /// <summary>
        /// Uni test to check if the add point works properly
        /// </summary>
        /// <param name="player1Points">The player1 current points</param>
        /// <param name="player2Points">The player2 current points</param>
        /// <param name="playerPointWinner">The player point winner</param>
        /// <param name="resultPlayer1Points">The expected player1 points</param>
        /// <param name="resultPlayer2Points">The expected player2 points.</param>
        [DataRow(0, 0, "Player1", "15", "0")]
        [DataRow(0, 1, "Player1", "15", "15")]
        [DataRow(0, 2, "Player1", "15", "30")]
        [DataRow(0, 3, "Player1", "15", "40")]
        [DataRow(1, 0, "Player1", "30", "0")]
        [DataRow(1, 1, "Player1", "30", "15")]
        [DataRow(1, 2, "Player1", "30", "30")]
        [DataRow(1, 3, "Player1", "30", "40")]
        [DataRow(2, 0, "Player1", "40", "0")]
        [DataRow(2, 1, "Player1", "40", "15")]
        [DataRow(2, 2, "Player1", "40", "30")]
        [DataRow(2, 3, "Player1", "deuce", "deuce")]
        [DataRow(3, 0, "Player1", "game", "0")]
        [DataRow(3, 1, "Player1", "game", "15")]
        [DataRow(3, 2, "Player1", "game", "30")]
        [DataRow(3, 3, "Player1", "adv", "")]
        [DataRow(4, 3, "Player1", "game", "0")]
        [DataRow(0, 0, "Player2", "0", "15")]
        [DataRow(0, 1, "Player2", "0", "30")]
        [DataRow(0, 2, "Player2", "0", "40")]
        [DataRow(0, 3, "Player2", "0", "game")]
        [DataRow(1, 0, "Player2", "15", "15")]
        [DataRow(1, 1, "Player2", "15", "30")]
        [DataRow(1, 2, "Player2", "15", "40")]
        [DataRow(1, 3, "Player2", "15", "game")]
        [DataRow(2, 0, "Player2", "30", "15")]
        [DataRow(2, 1, "Player2", "30", "30")]
        [DataRow(2, 2, "Player2", "30", "40")]
        [DataRow(2, 3, "Player2", "30", "game")]
        [DataRow(3, 0, "Player2", "40", "15")]
        [DataRow(3, 1, "Player2", "40", "30")]
        [DataRow(3, 2, "Player2", "deuce", "deuce")]
        [DataRow(3, 3, "Player2", "", "adv")]
        [DataRow(3, 4, "Player2", "0", "game")]
        [DataTestMethod]
        public void AddPointTest(int player1Points, int player2Points, string playerPointWinner, string resultPlayer1Points, string resultPlayer2Points)
        {
            // arrange
            var sessionContext = new SessionContext();
            var refereePanelViewModel = new RefereePanelViewModel(sessionContext);
            var scoreboardViewModel = new ScoreboardViewModel(sessionContext);

            // act
            sessionContext.Player1Name = "Player1";
            sessionContext.Player2Name = "Player2";
            refereePanelViewModel.StartMatch(null);

            generateMatchGamePoints(refereePanelViewModel, player1Points, player2Points); // Generate a match with the requested current points
            refereePanelViewModel.AddPlayerPoint(playerPointWinner); // Add one point to the player

            // assert
            Assert.AreEqual(resultPlayer1Points, scoreboardViewModel.SessionContext.Player1GameScore);
            Assert.AreEqual(resultPlayer2Points, scoreboardViewModel.SessionContext.Player2GameScore);
        }

        /// <summary>
        /// Auxiliar method to generate the desired game players scores from the referee panel view model
        /// </summary>
        /// <param name="refereePanel">Referee panel view model instance</param>
        /// <param name="player1Points">Player1 points inside the game</param>
        /// <param name="player2Points">Player2 points inside the game</param>
        private void generateMatchGamePoints(RefereePanelViewModel refereePanel, int player1Points, int player2Points)
        {
            var maxPointsValue = player1Points > player2Points ? player1Points : player2Points;

            var i = 0;
            while (i < maxPointsValue)
            {
                if (player1Points - i > 0)
                    refereePanel.AddPlayerPoint("Player1");
                if (player2Points - i > 0)
                    refereePanel.AddPlayerPoint("Player2");

                i++;
            }
        }

        /// <summary>
        /// Unit test to check if the infromation text is correct when a point is added
        /// </summary>
        /// <param name="playerPointWinner">The player point winner</param>
        [DataRow("Player1")]
        [DataRow("Player2")]
        [DataTestMethod]
        public void AddPointPlayerInformationTextTest(string playerPointWinner)
        {
            // arrange
            var sessionContext = new SessionContext();
            var refereePanelViewModel = new RefereePanelViewModel(sessionContext);
            var scoreboardViewModel = new ScoreboardViewModel(sessionContext);

            // act
            sessionContext.Player1Name = "Player1";
            sessionContext.Player2Name = "Player2";
            refereePanelViewModel.StartMatch(null);
            refereePanelViewModel.AddPlayerPoint(playerPointWinner);

            // assert
            Assert.AreEqual(playerPointWinner + " won the POINT",
                            refereePanelViewModel.SessionContext.RefereeInfo);
        }

        /// <summary>
        /// Unit test to check if the player server information is properly updated
        /// </summary>
        /// <param name="playerServer">The player currently serving</param>
        [DataRow("Player1")]
        [DataRow("Player2")]
        [DataTestMethod]
        public void PlayerServerTest(string playerServer)
        {
            // arrange
            var sessionContext = new SessionContext();
            var refereePanelViewModel = new RefereePanelViewModel(sessionContext);
            var scoreboardViewModel = new ScoreboardViewModel(sessionContext);

            // act
            sessionContext.Player1Name = "Player1";
            sessionContext.Player2Name = "Player2";
            refereePanelViewModel.StartMatch(null);

            GeneratePlayerWonGame(refereePanelViewModel, "Player1"); // Generate a finished game
            refereePanelViewModel.AddPlayerPoint("Player1");
            if (playerServer == "Player2") // because the player1 starts serving the first point in the match
            {
                GeneratePlayerWonGame(refereePanelViewModel, "Player1"); // Generate a finished game
                refereePanelViewModel.AddPlayerPoint("Player1");
            }
            refereePanelViewModel.AddPlayerPoint("Player1");

            // assert
            if (playerServer == "Player1")
            {
                Assert.IsFalse(scoreboardViewModel.SessionContext.Player1Server);
                Assert.IsTrue(scoreboardViewModel.SessionContext.Player2Server);
            }
            else
            {
                Assert.IsTrue(scoreboardViewModel.SessionContext.Player1Server);
                Assert.IsFalse(scoreboardViewModel.SessionContext.Player2Server);
            }
        }

        /// <summary>
        /// Auxiliar method to generatea a player won game
        /// </summary>
        /// <param name="refereePanelViewModel">The referee panel view model</param>
        /// <param name="playerGameWinner">The player game winner</param>
        private void GeneratePlayerWonGame(RefereePanelViewModel refereePanelViewModel, string playerGameWinner)
        {
            for (var j = 0; j < 4; j++)
                refereePanelViewModel.AddPlayerPoint(playerGameWinner);
        }

        /// <summary>
        /// Unit test to check a won game by a player
        /// </summary>
        [DataRow("Player1")]
        [DataRow("Player2")]
        [DataTestMethod]
        public void PlayerWonGameTest(string playerWinner)
        {
            // arrange
            var sessionContext = new SessionContext();
            var refereePanelViewModel = new RefereePanelViewModel(sessionContext);
            var scoreboardViewModel = new ScoreboardViewModel(sessionContext);

            // act & assert
            sessionContext.Player1Name = "Player1";
            sessionContext.Player2Name = "Player2";
            refereePanelViewModel.StartMatch(null);
            GeneratePlayerWonGame(refereePanelViewModel, playerWinner);

            // assert
            if (playerWinner == "Player1")
            {
                Assert.AreEqual(1, scoreboardViewModel.SessionContext.Player1WonGamesSet1);
                Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player2WonGamesSet1);
            }
            else
            {
                Assert.AreEqual(0, scoreboardViewModel.SessionContext.Player1WonGamesSet1);
                Assert.AreEqual(1, scoreboardViewModel.SessionContext.Player2WonGamesSet1);
            }
            Assert.AreEqual(playerWinner + " won the GAME",
                refereePanelViewModel.SessionContext.RefereeInfo);
        }

        /// <summary>
        /// Unit test to check a full match
        /// </summary>
        [TestMethod]
        public void FullMatchTest()
        {
            // arrange
            var sessionContext = new SessionContext();
            var refereePanelViewModel = new RefereePanelViewModel(sessionContext);
            var scoreboardViewModel = new ScoreboardViewModel(sessionContext);

            // act & assert
            sessionContext.Player1Name = "Player1";
            sessionContext.Player2Name = "Player2";
            refereePanelViewModel.StartMatch(null);

            // set 1
            GeneratePlayerWonGame(refereePanelViewModel, "Player2");
            for (var j = 0; j < 6; j++) // games iterations 
            {
                GeneratePlayerWonGame(refereePanelViewModel, "Player1");
                Assert.AreEqual(j + 1, scoreboardViewModel.SessionContext.Player1WonGamesSet1);
                Assert.AreEqual(1, scoreboardViewModel.SessionContext.Player2WonGamesSet1);
                if (j != 5)
                    Assert.AreEqual("Player1 won the GAME",
                        refereePanelViewModel.SessionContext.RefereeInfo);
                else
                    Assert.AreEqual("Player1 won the SET",
                        refereePanelViewModel.SessionContext.RefereeInfo);
            }

            // set 2
            GeneratePlayerWonGame(refereePanelViewModel, "Player1");
            for (var j = 0; j < 6; j++) // games iterations 
            {
                GeneratePlayerWonGame(refereePanelViewModel, "Player2");
                Assert.AreEqual(1, scoreboardViewModel.SessionContext.Player1WonGamesSet2);
                Assert.AreEqual(j + 1, scoreboardViewModel.SessionContext.Player2WonGamesSet2);
                if (j != 5)
                    Assert.AreEqual("Player2 won the GAME",
                        refereePanelViewModel.SessionContext.RefereeInfo);
                else
                    Assert.AreEqual("Player2 won the SET",
                        refereePanelViewModel.SessionContext.RefereeInfo);
            }

            // set 3
            GeneratePlayerWonGame(refereePanelViewModel, "Player2");
            for (var j = 0; j < 6; j++) // games iterations 
            {
                GeneratePlayerWonGame(refereePanelViewModel, "Player1");
                Assert.AreEqual(j + 1, scoreboardViewModel.SessionContext.Player1WonGamesSet3);
                Assert.AreEqual(1, scoreboardViewModel.SessionContext.Player2WonGamesSet3);
                if (j != 5)
                    Assert.AreEqual("Player1 won the GAME",
                        refereePanelViewModel.SessionContext.RefereeInfo);
                else
                    Assert.AreEqual("Player1 won the SET",
                        refereePanelViewModel.SessionContext.RefereeInfo);
            }

            // set 4
            GeneratePlayerWonGame(refereePanelViewModel, "Player1");
            for (var j = 0; j < 6; j++) // games iterations 
            {
                GeneratePlayerWonGame(refereePanelViewModel, "Player2");
                Assert.AreEqual(1, scoreboardViewModel.SessionContext.Player1WonGamesSet4);
                Assert.AreEqual(j + 1, scoreboardViewModel.SessionContext.Player2WonGamesSet4);
                if (j != 5)
                    Assert.AreEqual("Player2 won the GAME",
                        refereePanelViewModel.SessionContext.RefereeInfo);
                else
                    Assert.AreEqual("Player2 won the SET",
                        refereePanelViewModel.SessionContext.RefereeInfo);
            }

            // set 5
            GeneratePlayerWonGame(refereePanelViewModel, "Player2");
            for (var j = 0; j < 6; j++) // games iterations 
            {
                GeneratePlayerWonGame(refereePanelViewModel, "Player1");
                Assert.AreEqual(j + 1, scoreboardViewModel.SessionContext.Player1WonGamesSet5);
                Assert.AreEqual(1, scoreboardViewModel.SessionContext.Player2WonGamesSet5);
                if (j != 5)
                    Assert.AreEqual("Player1 won the GAME",
                        refereePanelViewModel.SessionContext.RefereeInfo);
                else
                    Assert.AreEqual("Match finished!",
                        refereePanelViewModel.SessionContext.RefereeInfo);
            }
        }
    }
}
