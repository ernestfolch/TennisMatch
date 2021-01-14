﻿namespace TennisMatch
{
    /// <summary>
    /// Enum used to refer the match player1 or the match player2
    /// </summary>
    public enum PlayerOrder
    {
        player1,
        player2
    }

    public class Match
    {
        private Player Player1 { get; set; }
        private Player Player2 { get; set; }

        /// <summary>
        /// Match class constructor
        /// </summary>
        /// <param name="player1Name">Name of the first match player</param>
        /// <param name="player2Name">Name of the second match player</param>
        public Match(string player1Name, string player2Name)
        {
            Player1 = new Player(player1Name);
            Player2 = new Player(player2Name);
        }

        /// <summary>
        /// Method to get the match player names 
        /// </summary>
        /// <param name="playerOrder">Player referred</param>
        /// <returns>The name of the player</returns>
        public string GetPlayerName(PlayerOrder playerOrder)
        {
            if (playerOrder == PlayerOrder.player1)
                return Player1.Name;
            else
                return Player2.Name;
        }
    }
}
