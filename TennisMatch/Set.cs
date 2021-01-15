namespace TennisMatch
{
    /// <summary>
    /// Internal class to manage the match sets
    /// </summary>
    internal class Set
    {
        #region properties        
        /// <summary>
        /// Gets or sets the player1 won games
        /// </summary>
        /// <value>The player1 won games</value>
        internal int Player1Games { get; set; }
        /// <summary>
        /// Gets or sets the player2 won games
        /// </summary>
        /// <value>The player2 won games</value>
        internal int Player2Games { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this set is finished.
        /// </summary>
        /// <value><c>true</c> if this set is finished; otherwise, <c>false</c>.</value>
        internal bool IsFinished { get; set; }
        #endregion

        #region constructor
        /// <summary>
        /// Class constructor
        /// </summary>
        public Set()
        {
            Player1Games = 0;
            Player2Games = 0;

            IsFinished = false;
        }
        #endregion

        #region methods
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

            if ((Player1Games == 6 && Player2Games < 5) || // normal game
                (Player2Games == 6 && Player1Games < 5))
                IsFinished = true;

            if (Player1Games == 7 || Player2Games == 7) // tie break
                IsFinished = true;
        }
        #endregion
    }
}
