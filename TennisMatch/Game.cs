namespace TennisMatch
{
    /// <summary>
    /// Internal class to manage the games inside sets
    /// </summary>
    internal class Game
    {
        public int Player1Points { get; set; }
        public int Player2Points { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        public Game()
        {
            Player1Points = 0;
            Player2Points = 0;
        }

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
                    return (playerPoints > opponentPoints) ? "game" : "";
            }
        }
    }
}
