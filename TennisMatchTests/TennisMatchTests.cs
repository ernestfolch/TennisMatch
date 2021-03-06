﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        /// Unit test to check if the game scores starts with 0 points for each player
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
        /// Auxiliar method to generate the desired game players scores
        /// </summary>
        /// <param name="match">Match instance</param>
        /// <param name="player1Points">Player1 points inside the game</param>
        /// <param name="player2Points">Player2 points inside the game</param>
        private void generateMatchGamePoints(Match match, int player1Points, int player2Points)
        {
            var maxPointsValue = player1Points > player2Points ? player1Points : player2Points;

            var i = 0;
            while (i < maxPointsValue)
            {
                if (player1Points - i > 0)
                    match.AddPlayerPoint(PlayerOrder.player1);
                if (player2Points - i > 0)
                    match.AddPlayerPoint(PlayerOrder.player2);

                i++;
            }
        }

        /// <summary>
        /// Unit test to check if the player add points works
        /// </summary>
        /// <param name="player1Points">Player1 points inside the game</param>
        /// <param name="player2Points">Player2 points inside the game</param>
        /// <param name="playerPointWinner">Player who did the point</param>
        /// <param name="playerPoint">Player who won the point</param>
        /// <param name="resultPlayer1Points">Expected player1 points after the player point</param>
        /// <param name="resultPlayer2Points">Expected player1 points after the player point</param> 
        [DataRow(0, 0, PlayerOrder.player1, "15", "0")]
        [DataRow(0, 1, PlayerOrder.player1, "15", "15")]
        [DataRow(0, 2, PlayerOrder.player1, "15", "30")]
        [DataRow(0, 3, PlayerOrder.player1, "15", "40")]
        [DataRow(1, 0, PlayerOrder.player1, "30", "0")]
        [DataRow(1, 1, PlayerOrder.player1, "30", "15")]
        [DataRow(1, 2, PlayerOrder.player1, "30", "30")]
        [DataRow(1, 3, PlayerOrder.player1, "30", "40")]
        [DataRow(2, 0, PlayerOrder.player1, "40", "0")]
        [DataRow(2, 1, PlayerOrder.player1, "40", "15")]
        [DataRow(2, 2, PlayerOrder.player1, "40", "30")]
        [DataRow(2, 3, PlayerOrder.player1, "deuce", "deuce")]
        [DataRow(3, 0, PlayerOrder.player1, "game", "0")]
        [DataRow(3, 1, PlayerOrder.player1, "game", "15")]
        [DataRow(3, 2, PlayerOrder.player1, "game", "30")]
        [DataRow(3, 3, PlayerOrder.player1, "adv", "")]
        [DataRow(4, 3, PlayerOrder.player1, "game", "0")]
        [DataRow(0, 0, PlayerOrder.player2, "0", "15")]
        [DataRow(0, 1, PlayerOrder.player2, "0", "30")]
        [DataRow(0, 2, PlayerOrder.player2, "0", "40")]
        [DataRow(0, 3, PlayerOrder.player2, "0", "game")]
        [DataRow(1, 0, PlayerOrder.player2, "15", "15")]
        [DataRow(1, 1, PlayerOrder.player2, "15", "30")]
        [DataRow(1, 2, PlayerOrder.player2, "15", "40")]
        [DataRow(1, 3, PlayerOrder.player2, "15", "game")]
        [DataRow(2, 0, PlayerOrder.player2, "30", "15")]
        [DataRow(2, 1, PlayerOrder.player2, "30", "30")]
        [DataRow(2, 2, PlayerOrder.player2, "30", "40")]
        [DataRow(2, 3, PlayerOrder.player2, "30", "game")]
        [DataRow(3, 0, PlayerOrder.player2, "40", "15")]
        [DataRow(3, 1, PlayerOrder.player2, "40", "30")]
        [DataRow(3, 2, PlayerOrder.player2, "deuce", "deuce")]
        [DataRow(3, 3, PlayerOrder.player2, "", "adv")]
        [DataRow(3, 4, PlayerOrder.player2, "0", "game")]
        [DataTestMethod]
        public void AddPlayersPointsTest(int player1Points, int player2Points, PlayerOrder playerPointWinner, string resultPlayer1Points, string resultPlayer2Points)
        {
            // arrange
            var match = new Match("Player1 Name", "Player2 Name");

            // act
            generateMatchGamePoints(match, player1Points, player2Points); // Generate a match with the requested current points
            match.AddPlayerPoint(playerPointWinner); // Add one point to the player

            // assert
            Assert.AreEqual(resultPlayer1Points, match.GetPlayerGameScore(PlayerOrder.player1));
            Assert.AreEqual(resultPlayer2Points, match.GetPlayerGameScore(PlayerOrder.player2));
        }

        /// <summary>
        /// Unit test to check if the match starts with 5 sets and each set starts with 0 won games for each player
        /// </summary>
        [TestMethod]
        public void PlayersSetScoresTest()
        {
            // arrange
            var match = new Match("Player1 Name", "Player2 Name");

            // assert
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(0, match.GetPlayerSetScore(PlayerOrder.player1, i));
                Assert.AreEqual(0, match.GetPlayerSetScore(PlayerOrder.player2, i));
            }
        }

        /// <summary>
        /// Auxiliar method to generate a game won by the player
        /// </summary>
        /// <param name="match">Match instance</param>
        /// <param name="player">Player who has to won the game</param>
        private void GeneratePlayerWonGame(Match match, PlayerOrder player)
        {
            for (var j = 0; j < 4; j++)
                match.AddPlayerPoint(player);
        }

        /// <summary>
        /// Unit test to check games won inside the sets
        /// </summary>
        [TestMethod]
        public void PlayerWonGamesTest()
        {
            // arrange
            var match = new Match("Player1 Name", "Player2 Name");

            // act & assert
            for (var i = 0; i < 3; i++) // set iterations 
            {
                for (var j = 0; j < 6; j++) // games iterations 
                {
                    GeneratePlayerWonGame(match, PlayerOrder.player1);

                    Assert.AreEqual(j + 1, match.GetPlayerSetScore(PlayerOrder.player1, i));
                    Assert.AreEqual(0, match.GetPlayerSetScore(PlayerOrder.player2, i));
                    Assert.IsTrue(match.IsGameFinished());
                }

                Assert.IsTrue(match.IsSetFinished());
            }
        }

        /// <summary>
        /// Unit test to check if the tie break special game is working
        /// </summary>
        [TestMethod]
        public void PlayerWonTieBreakSetTest()
        {
            // arrange
            var match = new Match("Player1 Name", "Player2 Name");

            // act
            // generate a match at 5-5 sets
            for (var i = 0; i < 5; i++)
                GeneratePlayerWonGame(match, PlayerOrder.player1);
            for (var i = 0; i < 5; i++)
                GeneratePlayerWonGame(match, PlayerOrder.player2);

            // generate a tie brak 6-6
            GeneratePlayerWonGame(match, PlayerOrder.player1);
            GeneratePlayerWonGame(match, PlayerOrder.player2);

            // add point to the tie break
            match.AddPlayerPoint(PlayerOrder.player1);
            match.AddPlayerPoint(PlayerOrder.player1);
            match.AddPlayerPoint(PlayerOrder.player2);

            // assert
            Assert.AreEqual("2", match.GetPlayerGameScore(PlayerOrder.player1));
            Assert.AreEqual("1", match.GetPlayerGameScore(PlayerOrder.player2));
        }

        /// <summary>
        /// Unit test to check the scores inside a tie break
        /// </summary>
        [TestMethod]
        public void TieBreakScoresTest()
        {
            // arrange
            var match = new Match("Player1 Name", "Player2 Name");

            // act
            // generate a match at 6-6 sets
            for (var i = 0; i < 6; i++)
            {
                GeneratePlayerWonGame(match, PlayerOrder.player1);
                GeneratePlayerWonGame(match, PlayerOrder.player2);
            }

            // add player1 6 points
            for (var i = 0; i < 6; i++)
                match.AddPlayerPoint(PlayerOrder.player1);

            // arrange
            Assert.AreEqual("6", match.GetPlayerGameScore(PlayerOrder.player1));
            Assert.AreEqual("0", match.GetPlayerGameScore(PlayerOrder.player2));
        }

        /// <summary>
        /// Unit test to check that the tie break is properly finished when 6-6
        /// </summary>
        [TestMethod]
        public void TieBreakFinishedByTwoPointsTest()
        {
            // arrange
            var match = new Match("Player1 Name", "Player2 Name");

            // act
            // generate a match at 6-6 sets
            for (var i = 0; i < 6; i++)
            {
                GeneratePlayerWonGame(match, PlayerOrder.player1);
                GeneratePlayerWonGame(match, PlayerOrder.player2);
            }

            // add player2 5 points
            for (var i = 0; i < 5; i++)
                match.AddPlayerPoint(PlayerOrder.player2);

            // add player1 5 points
            for (var i = 0; i < 5; i++)
                match.AddPlayerPoint(PlayerOrder.player1);

            // to generate the 7-6
            match.AddPlayerPoint(PlayerOrder.player1);
            match.AddPlayerPoint(PlayerOrder.player2);
            match.AddPlayerPoint(PlayerOrder.player1);

            // arrange
            Assert.AreEqual("7", match.GetPlayerGameScore(PlayerOrder.player1));
            Assert.AreEqual("6", match.GetPlayerGameScore(PlayerOrder.player2));
        }

        /// <summary>
        /// Auxiliar method to generate the desired set players won games
        /// </summary>
        /// <param name="match">Match instance</param>
        /// <param name="player1Sets">Player1 won games inside the set</param>
        /// <param name="player2Sets">Player2 won games inside the set</param>
        private void generateMatchWonSets(Match match, int player1Sets, int player2Sets)
        {
            var maxSetsValue = player1Sets > player2Sets ? player1Sets : player2Sets;

            var i = 0;
            while (i < maxSetsValue)
            {
                if (player1Sets - i > 0)
                    for (var k = 0; k < 6; k++)
                        GeneratePlayerWonGame(match, PlayerOrder.player1);
                if (player2Sets - i > 0)
                    for (var k = 0; k < 6; k++)
                        GeneratePlayerWonGame(match, PlayerOrder.player2);

                i++;
            }
        }

        /// <summary>
        /// Unit test to check the match finish
        /// </summary>
        [DataRow(0, 0, false)]
        [DataRow(0, 1, false)]
        [DataRow(0, 2, false)]
        [DataRow(1, 0, false)]
        [DataRow(1, 1, false)]
        [DataRow(1, 2, false)]
        [DataRow(2, 0, false)]
        [DataRow(2, 1, false)]
        [DataRow(2, 2, false)]
        [DataRow(0, 3, true)]
        [DataRow(3, 0, true)]
        [DataRow(3, 1, true)]
        [DataRow(1, 3, true)]
        [DataRow(2, 3, true)]
        [DataRow(3, 2, true)]
        [DataTestMethod]
        public void PlayerWonMatchTest(int player1Sets, int player2Sets, bool result)
        {
            // arrange
            var match = new Match("Player1 Name", "Player2 Name");

            // act
            generateMatchWonSets(match, player1Sets, player2Sets);

            // arrange
            if (result)
                Assert.IsTrue(match.IsMatchFinished());
            else
                Assert.IsFalse(match.IsMatchFinished());
        }

        /// <summary>
        /// Unit test to check if the game server is the correct one
        /// </summary>
        [TestMethod]
        public void PlayerServerTest()
        {
            // arrange
            var match = new Match("Player1 Name", "Player2 Name");

            // act
            GeneratePlayerWonGame(match, PlayerOrder.player1);
            GeneratePlayerWonGame(match, PlayerOrder.player1);
            match.AddPlayerPoint(PlayerOrder.player2);

            // assert
            Assert.AreEqual(PlayerOrder.player1, match.GetPlayerServer());
        }
    }
}
