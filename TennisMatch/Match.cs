namespace TennisMatch
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
        private const int NumberOfSets = 5;

        private Player Player1 { get; set; }
        private Player Player2 { get; set; }
        private Game CurrentGame { get; set; }
        private Set[] Sets { get; set; } = new Set[NumberOfSets];
        private int CurrentSet { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="player1Name">Name of the first match player</param>
        /// <param name="player2Name">Name of the second match player</param>
        public Match(string player1Name, string player2Name)
        {
            Player1 = new Player(player1Name);
            Player2 = new Player(player2Name);

            CurrentGame = new Game();

            CurrentSet = 0;
            for (var i = 0; i < NumberOfSets; i++)
                Sets[i] = new Set();
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

        /// <summary>
        /// Method to get the referred player score inside the current game
        /// </summary>
        /// <param name="playerOrder">Player referred</param>
        /// <returns>String containing the player current game score</returns>
        public string GetPlayerGameScore(PlayerOrder playerOrder)
        {
            return CurrentGame.GetPlayerPoints(playerOrder);
        }

        /// <summary>
        /// Method to add one point to a player
        /// </summary>
        /// <param name="playerOrder">Player referred</param>
        /// <returns>String with the referred player current score in the current game</returns>
        public string AddPlayerPoint(PlayerOrder playerOrder)
        {
            if (CurrentGame.IsFinished)
                CurrentGame = new Game();

            if (playerOrder == PlayerOrder.player1)
                CurrentGame.Player1Points++;
            else
                CurrentGame.Player2Points++;

            var points = CurrentGame.GetPlayerPoints(playerOrder);
            if (CurrentGame.IsFinished)
                Sets[CurrentSet].AddPlayerGame(playerOrder);

            return points;
        }

        /// <summary>
        /// Method to ge the games won by a player in an specific set
        /// </summary>
        /// <param name="playerOrder">Player referred</param>
        /// <param name="setNumber">Number of the set</param>
        /// <returns>Integer with the referred player total amount of won sets</returns>
        public int GetPlayerSetScore(PlayerOrder playerOrder, int setNumber)
        {
            if (playerOrder == PlayerOrder.player1)
                return Sets[setNumber].Player1Games;
            else
                return Sets[setNumber].Player2Games;
        }
    }
}
