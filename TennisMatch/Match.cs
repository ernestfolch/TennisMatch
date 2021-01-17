namespace TennisMatch
{
    /// <summary>
    /// Enum used to refer the match player1 or the match player2
    /// </summary>
    public enum PlayerOrder
    {
        /// <summary>
        /// The match player1
        /// </summary>
        player1,
        /// <summary>
        /// The match player2
        /// </summary>
        player2
    }

    /// <summary>
    /// Public class to manage a tennis match between two players
    /// </summary>
    public class Match
    {
        #region fields        
        /// <summary>
        /// The number of sets defined in a match
        /// </summary>
        private const int NumberOfSets = 5;
        #endregion

        #region properties        
        /// <summary>
        /// Gets or sets the player1
        /// </summary>
        /// <value>The player1</value>
        private Player Player1 { get; set; }
        /// <summary>
        /// Gets or sets the player2
        /// </summary>
        /// <value>The player2</value>
        private Player Player2 { get; set; }
        /// <summary>
        /// Gets or sets the current tennis game
        /// </summary>
        /// <value>The current tennis game</value>
        private Game CurrentGame { get; set; }
        /// <summary>
        /// Gets or sets the number of sets in a match
        /// </summary>
        /// <value>The sets defined in a match</value>
        private Set[] Sets { get; set; } = new Set[NumberOfSets];
        /// <summary>
        /// Gets or sets the current tennis set
        /// </summary>
        /// <value>The current tennis set</value>
        private int CurrentSet { get; set; }
        /// <summary>
        /// Gets or sets the won player1 sets
        /// </summary>
        /// <value>The player1 won sets</value>
        private int Player1Sets { get; set; }
        /// <summary>
        /// Gets or sets the won player2 sets
        /// </summary>
        /// <value>The player2 won sets</value>
        private int Player2Sets { get; set; }
        #endregion

        #region constructor
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="player1Name">Name of the first match player</param>
        /// <param name="player2Name">Name of the second match player</param>
        public Match(string player1Name, string player2Name)
        {
            Player1 = new Player(player1Name);
            Player2 = new Player(player2Name);

            CurrentSet = 0;
            for (var i = 0; i < NumberOfSets; i++)
                Sets[i] = new Set();

            CurrentGame = StartNewGame();
        }
        #endregion

        #region methods
        /// <summary>
        /// Auxiliar method to create new game deciding if it is a tie break or not
        /// </summary>
        private Game StartNewGame()
        {
            var isTieBreak = false;

            if (Sets[CurrentSet].Player1Games == 6 &&
                Sets[CurrentSet].Player2Games == 6)
                isTieBreak = true;

            return new Game(isTieBreak, CurrentGame?.PlayerServer);
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
            if (IsMatchFinished())
                return string.Empty;

            if (CurrentGame.IsFinished)
                CurrentGame = StartNewGame();

            if (playerOrder == PlayerOrder.player1)
                CurrentGame.Player1Points++;
            else
                CurrentGame.Player2Points++;

            var points = CurrentGame.GetPlayerPoints(playerOrder);
        
            if (CurrentGame.IsFinished)
            {
                Sets[CurrentSet].AddPlayerGame(playerOrder);
                if (Sets[CurrentSet].IsFinished)
                {
                    if (playerOrder == PlayerOrder.player1)
                        Player1Sets++;
                    else
                        Player2Sets++;

                    CurrentSet++;
                }
            }

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

        /// <summary>
        /// Method to check if a match is finished or not
        /// </summary>
        /// <returns>Boolean indicating if the match is finished or not</returns>
        public bool IsMatchFinished()
        {
            var matchBorder = (float)NumberOfSets / (float)2;
            if (Player1Sets >= matchBorder || Player2Sets >= matchBorder)
                return true;

            return false;
        }

        /// <summary>
        /// Method to check if a game is finished or not
        /// </summary>
        /// <returns>Boolean indicating if the game is finished or not</returns>
        public bool IsGameFinished()
        {
            return CurrentGame.IsFinished;
        }

        /// <summary>
        /// Method to check if a set is finished or not
        /// </summary>
        /// <returns>Boolean indicating if the set is finished or not</returns>
        public bool IsSetFinished()
        {
            if (CurrentSet == 0)
                return false;

            if (Sets[CurrentSet - 1].IsFinished &&
                Sets[CurrentSet].Player1Games == 0 &&
                Sets[CurrentSet].Player2Games == 0 &&
                CurrentGame.IsFinished)
                return true;

            return false;
        }

        /// <summary>
        /// Method to get the current game player server
        /// </summary>
        /// <returns></returns>
        public PlayerOrder GetPlayerServer()
        {
            return CurrentGame.PlayerServer;
        }
        #endregion
    }
}
