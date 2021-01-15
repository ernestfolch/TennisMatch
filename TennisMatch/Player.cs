namespace TennisMatch
{
    /// <summary>
    /// Internal class to manage the match players information
    /// </summary>
    internal class Player
    {
        #region properties        
        /// <summary>
        /// Gets or sets the player name
        /// </summary>
        /// <value>The player name</value>
        internal string Name { get; set; }
        #endregion

        #region constructor
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="name">String containing the player name</param>
        public Player(string name)
        {
            Name = name;
        }
        #endregion
    }
}
