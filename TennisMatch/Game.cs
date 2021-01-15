﻿using System;

namespace TennisMatch
{
    /// <summary>
    /// Internal class to manage the games inside sets
    /// </summary>
    internal class Game
    {
        #region properties
        /// <summary>
        /// Gets or sets the player1 points
        /// </summary>
        /// <value>The player1 points</value>
        internal int Player1Points { get; set; }
        /// <summary>
        /// Gets or sets the player2 points
        /// </summary>
        /// <value>The player2 points</value>
        internal int Player2Points { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this game is finished.
        /// </summary>
        /// <value><c>true</c> if this game is finished; otherwise, <c>false</c>.</value>
        internal bool IsFinished { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is tie break.
        /// </summary>
        /// <value><c>true</c> if this instance is tie break; otherwise, <c>false</c>.</value>
        private bool IsTieBreak { get; set; }
        #endregion

        #region constructor
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="isTieBreak">To define if the game is a tie break or a normal game</param>
        public Game(bool isTieBreak = false)
        {
            Player1Points = 0;
            Player2Points = 0;

            IsFinished = false;
            IsTieBreak = isTieBreak;
        }
        #endregion

        #region methods
        /// <summary>
        /// Method to get the tennis score for the referred player
        /// </summary>
        /// <param name="playerOrder">Player referred</param>
        /// <returns>String containing the tennis score for the referred player</returns>
        public string GetPlayerPoints(PlayerOrder playerOrder)
        {
            if (playerOrder == PlayerOrder.player1)
                return TranslateScore(Player1Points, Player2Points);
            else
                return TranslateScore(Player2Points, Player1Points);
        }

        /// <summary>
        /// Private method to convert the secuential scores to tennis scores
        /// </summary>
        /// <param name="playerPoints">Current referred player's scores</param>
        /// <param name="opponentPoints">Current opponent player's scores</param>
        /// <returns>String containing the tennis score for the referred player</returns>
        private string TranslateScore(int playerPoints, int opponentPoints)
        {
            // the current game is a tie break game
            if (IsTieBreak)
            {
                if ((playerPoints >= 6 || opponentPoints >= 6) &&
                    Math.Abs(playerPoints - opponentPoints) >= 2)
                    IsFinished = true;

                return playerPoints.ToString();
            }

            // players scores arrived to deuce (40-40)
            if (playerPoints >= 3 && opponentPoints >= 3)
            {
                if ((playerPoints >= 5) &&
                    Math.Abs(playerPoints - opponentPoints) >= 2)
                {
                    IsFinished = true;
                    return "game";
                }

                if ((opponentPoints >= 5) &&
                    Math.Abs(playerPoints - opponentPoints) >= 2)
                {
                    IsFinished = true;
                    return "0";
                }

                if (playerPoints == opponentPoints)
                    return "deuce";
                else if (playerPoints > opponentPoints)
                    return "adv";
                else
                    return "";
            }

            // normal game points
            switch (playerPoints)
            {
                case 3:
                    return "40";
                case 2:
                    return "30";
                case 1:
                    return "15";
                case 0:
                    return "0"; // love
                default:
                    if (playerPoints > opponentPoints)
                    {
                        IsFinished = true;
                        return "game";
                    }
                    else
                        return "";
            }
        }
        #endregion
    }
}
