namespace TennisMatch
{
    /// <summary>
    /// Internal class to manage the match sets
    /// </summary>
    internal class Set
    {
        public int Player1Games { get; set; }
        public int Player2Games { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        public Set()
        {
            Player1Games = 0;
            Player2Games = 0;
        }

        /// <summary>
        /// Method to add on won game to the player
        /// </summary>
        /// <param name="playerOrder">Player referred</param>
        public void AddPlayerGame(PlayerOrder playerOrder)
        {
            if (playerOrder == PlayerOrder.player1)
                Player1Games++;
            else
                Player2Games++;
        }
    }
}
