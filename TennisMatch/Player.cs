namespace TennisMatch
{
    /// <summary>
    /// Internal class to manage the match players information
    /// </summary>
    internal class Player
    {
        public string Name { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="name">String containing the player name</param>
        public Player(string name)
        {
            Name = name;
        }
    }
}
