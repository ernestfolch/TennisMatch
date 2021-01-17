using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TennisMatch.UI.Model
{
    public class SessionContext : INotifyPropertyChanged
    {
        #region properties
        /// <summary>
        /// Gets or sets the shared tennis match object
        /// </summary>
        /// <value>The shared tennis match shared</value>
        private Match Match { get; set; }
        private string _refereeInfo;
        public string RefereeInfo
        {
            get
            {
                return _refereeInfo;
            }
            set
            {
                _refereeInfo = value;
                OnPropertyChanged("RefereeInfo");
            }
        }

        #region Player1
        private string _player1Name;
        public string Player1Name
        {
            get
            {
                return _player1Name;
            }
            set
            {
                _player1Name = value;
                OnPropertyChanged("Player1Name");
            }
        }
        private bool _player1Server;
        public bool Player1Server
        {
            get
            {
                return _player1Server;
            }
            set
            {
                _player1Server = value;
                OnPropertyChanged("Player1Server");
            }
        }
        private string _player1GameScore;
        public string Player1GameScore
        {
            get
            {
                return _player1GameScore;
            }
            set
            {
                _player1GameScore = value;
                OnPropertyChanged("Player1GameScore");
            }
        }
        private int _player1WonGamesSet1;
        public int Player1WonGamesSet1
        {
            get
            {
                return _player1WonGamesSet1;
            }
            set
            {
                _player1WonGamesSet1 = value;
                OnPropertyChanged("Player1WonGamesSet1");
            }
        }
        private int _player1WonGamesSet2;
        public int Player1WonGamesSet2
        {
            get
            {
                return _player1WonGamesSet2;
            }
            set
            {
                _player1WonGamesSet2 = value;
                OnPropertyChanged("Player1WonGamesSet2");
            }
        }
        private int _player1WonGamesSet3;
        public int Player1WonGamesSet3
        {
            get
            {
                return _player1WonGamesSet3;
            }
            set
            {
                _player1WonGamesSet3 = value;
                OnPropertyChanged("Player1WonGamesSet3");
            }
        }
        private int _player1WonGamesSet4;
        public int Player1WonGamesSet4
        {
            get
            {
                return _player1WonGamesSet4;
            }
            set
            {
                _player1WonGamesSet4 = value;
                OnPropertyChanged("Player1WonGamesSet4");
            }
        }
        private int _player1WonGamesSet5;
        public int Player1WonGamesSet5
        {
            get
            {
                return _player1WonGamesSet5;
            }
            set
            {
                _player1WonGamesSet5 = value;
                OnPropertyChanged("Player1WonGamesSet5");
            }
        }
        #endregion

        #region Player2
        private string _player2Name;
        public string Player2Name
        {
            get
            {
                return _player2Name;
            }
            set
            {
                _player2Name = value;
                OnPropertyChanged("Player2Name");
            }
        }
        private bool _player2Server;
        public bool Player2Server
        {
            get
            {
                return _player2Server;
            }
            set
            {
                _player2Server = value;
                OnPropertyChanged("Player2Server");
            }
        }
        private string _player2GameScore;
        public string Player2GameScore
        {
            get
            {
                return _player2GameScore;
            }
            set
            {
                _player2GameScore = value;
                OnPropertyChanged("Player2GameScore");
            }
        }
        private int _player2WonGamesSet1;
        public int Player2WonGamesSet1
        {
            get
            {
                return _player2WonGamesSet1;
            }
            set
            {
                _player2WonGamesSet1 = value;
                OnPropertyChanged("Player2WonGamesSet1");
            }
        }
        private int _player2WonGamesSet2;
        public int Player2WonGamesSet2
        {
            get
            {
                return _player2WonGamesSet2;
            }
            set
            {
                _player2WonGamesSet2 = value;
                OnPropertyChanged("Player2WonGamesSet2");
            }
        }
        private int _player2WonGamesSet3;
        public int Player2WonGamesSet3
        {
            get
            {
                return _player2WonGamesSet3;
            }
            set
            {
                _player2WonGamesSet3 = value;
                OnPropertyChanged("Player2WonGamesSet3");
            }
        }
        private int _player2WonGamesSet4;
        public int Player2WonGamesSet4
        {
            get
            {
                return _player2WonGamesSet4;
            }
            set
            {
                _player2WonGamesSet4 = value;
                OnPropertyChanged("Player2WonGamesSet4");
            }
        }
        private int _player2WonGamesSet5;
        public int Player2WonGamesSet5
        {
            get
            {
                return _player2WonGamesSet5;
            }
            set
            {
                _player2WonGamesSet5 = value;
                OnPropertyChanged("Player2WonGamesSet5");
            }
        }
        #endregion
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Auxiliar method to initialize the match
        /// </summary>
        private void InitializeMatch()
        {
            Player1GameScore = "0";
            Player2GameScore = "0";
            Player1WonGamesSet1 = 0;
            Player1WonGamesSet2 = 0;
            Player1WonGamesSet3 = 0;
            Player1WonGamesSet4 = 0;
            Player1WonGamesSet5 = 0;
            Player2WonGamesSet1 = 0;
            Player2WonGamesSet2 = 0;
            Player2WonGamesSet3 = 0;
            Player2WonGamesSet4 = 0;
            Player2WonGamesSet5 = 0;
            Player1Server = true;
            Player2Server = false;
        }

        /// <summary>
        /// Method to start a tennis match
        /// </summary>
        public void StartMatch()
        {
            if (!string.IsNullOrEmpty(Player1Name) && !string.IsNullOrEmpty(Player2Name))
            {
                bool restartMatch = (Match == null) ? false : true;

                Match = new Match(Player1Name, Player2Name);

                // force the update the scoreboard with the initial 0-0 points and initial player server
                UpdatePlayerScores();
                UpdatePlayerServer();

                if (restartMatch) // new match started, update view with 0 points
                    InitializeMatch();

                RefereeInfo = "Match Started!";
            }
            else
                RefereeInfo = "You need to define the players names";
        }

        /// <summary>
        /// Method to add a game point to the referred player
        /// </summary>
        /// <param name="player">The referred player. The values can be Player1 or Player2</param>
        public void AddPoint(string player)
        {
            if (Match != null)
            {
                // add the point to the player
                if (player == "Player1")
                {
                    Match.AddPlayerPoint(PlayerOrder.player1);
                    RefereeInfo = "Player1 won the POINT";
                }
                else
                {
                    Match.AddPlayerPoint(PlayerOrder.player2);
                    RefereeInfo = "Player2 won the POINT";
                }

                // update the view with the new player scores
                Player1GameScore = Match.GetPlayerGameScore(PlayerOrder.player1);
                Player2GameScore = Match.GetPlayerGameScore(PlayerOrder.player2);

                UpdatePlayerScores(); // update the player scores
                UpdatePlayerServer(); // if needed, update the view with the player server
                UpdateWonGames(); // if needed, update the view with the won games

                if (Match.IsMatchFinished())
                    RefereeInfo = "Match finished!";
            }
            else
                RefereeInfo = "You need to start the match first";
        }

        /// <summary>
        /// Auxiliar method to update the won games inside the sets only if it is needed
        /// </summary>
        private void UpdateWonGames()
        {
            var winner = string.Empty;

            if (Player1WonGamesSet1 != Match.GetPlayerSetScore(PlayerOrder.player1, 0))
            {
                Player1WonGamesSet1 = Match.GetPlayerSetScore(PlayerOrder.player1, 0);
                winner = "Player1";
            }
            else if (Player2WonGamesSet1 != Match.GetPlayerSetScore(PlayerOrder.player2, 0))
            {
                Player2WonGamesSet1 = Match.GetPlayerSetScore(PlayerOrder.player2, 0);
                winner = "Player2";
            }
            else if (Player1WonGamesSet2 != Match.GetPlayerSetScore(PlayerOrder.player1, 1))
            {
                Player1WonGamesSet2 = Match.GetPlayerSetScore(PlayerOrder.player1, 1);
                winner = "Player1";
            }
            else if (Player2WonGamesSet2 != Match.GetPlayerSetScore(PlayerOrder.player2, 1))
            {
                Player2WonGamesSet2 = Match.GetPlayerSetScore(PlayerOrder.player2, 1);
                winner = "Player2";
            }
            else if (Player1WonGamesSet3 != Match.GetPlayerSetScore(PlayerOrder.player1, 2))
            {
                Player1WonGamesSet3 = Match.GetPlayerSetScore(PlayerOrder.player1, 2);
                winner = "Player1";
            }
            else if (Player2WonGamesSet3 != Match.GetPlayerSetScore(PlayerOrder.player2, 2))
            {
                Player2WonGamesSet3 = Match.GetPlayerSetScore(PlayerOrder.player2, 2);
                winner = "Player2";
            }
            else if (Player1WonGamesSet4 != Match.GetPlayerSetScore(PlayerOrder.player1, 3))
            {
                Player1WonGamesSet4 = Match.GetPlayerSetScore(PlayerOrder.player1, 3);
                winner = "Player1";
            }
            else if (Player2WonGamesSet4 != Match.GetPlayerSetScore(PlayerOrder.player2, 3))
            {
                Player2WonGamesSet4 = Match.GetPlayerSetScore(PlayerOrder.player2, 3);
                winner = "Player2";
            }
            else if (Player1WonGamesSet5 != Match.GetPlayerSetScore(PlayerOrder.player1, 4))
            {
                Player1WonGamesSet5 = Match.GetPlayerSetScore(PlayerOrder.player1, 4);
                winner = "Player1";
            }
            else if (Player2WonGamesSet5 != Match.GetPlayerSetScore(PlayerOrder.player2, 4))
            {
                Player2WonGamesSet5 = Match.GetPlayerSetScore(PlayerOrder.player2, 4);
                winner = "Player2";
            }

            if (Match.IsGameFinished())
                RefereeInfo = winner + " won the GAME";

            if (Match.IsSetFinished())
                RefereeInfo = winner + " won the SET";
        }

        /// <summary>
        /// Auxiliar method to update the player server
        /// </summary>
        private void UpdatePlayerServer()
        {
            if (Match.GetPlayerServer() == PlayerOrder.player1)
            {
                if (!Player1Server)
                {
                    Player1Server = true;
                    Player2Server = false;
                }
            }
            else
            {
                if (!Player2Server)
                {
                    Player2Server = true;
                    Player1Server = false;
                }
            }
        }

        private void UpdatePlayerScores()
        {
            Player1GameScore = Match.GetPlayerGameScore(PlayerOrder.player1);
            Player2GameScore = Match.GetPlayerGameScore(PlayerOrder.player2);
        }
    }
}
