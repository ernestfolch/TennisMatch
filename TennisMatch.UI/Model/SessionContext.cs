using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TennisMatch.UI.Model
{
    public class SessionContext : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the shared tennis match object
        /// </summary>
        /// <value>The shared tennis match shared</value>
        private Match Match { get; set; }

        #region Player1 properties
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
        public string Player1GameScore
        {
            get
            {
                return (Match != null) ? Match.GetPlayerGameScore(PlayerOrder.player1) : "0";
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

        #region Player2 properties
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
        public string Player2GameScore
        {
            get
            {
                return (Match != null) ? Match.GetPlayerGameScore(PlayerOrder.player2) : "0";
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Method to start a tennis match
        /// </summary>
        public void StartMatch()
        {
            if (!string.IsNullOrEmpty(Player1Name) && !string.IsNullOrEmpty(Player2Name))
                Match = new Match(Player1Name, Player2Name);
        }

        /// <summary>
        /// Method to add a game point to the referred player
        /// </summary>
        /// <param name="player">The referred player. The values can be Player1 or Player2</param>
        public void AddPoint(string player)
        {
            if (Match != null)
            {
                if (player == "Player1")
                    Match.AddPlayerPoint(PlayerOrder.player1);
                else
                    Match.AddPlayerPoint(PlayerOrder.player2);

                OnPropertyChanged("Player1GameScore");
                OnPropertyChanged("Player2GameScore");

                UpdateWonGames(); // if needed, update the view with the won games
            }
        }

        private void UpdateWonGames()
        {
            if (Player1WonGamesSet1 != Match.GetPlayerSetScore(PlayerOrder.player1, 0))
                Player1WonGamesSet1 = Match.GetPlayerSetScore(PlayerOrder.player1, 0);
            if (Player2WonGamesSet1 != Match.GetPlayerSetScore(PlayerOrder.player2, 0))
                Player2WonGamesSet1 = Match.GetPlayerSetScore(PlayerOrder.player2, 0);

            if (Player1WonGamesSet2 != Match.GetPlayerSetScore(PlayerOrder.player1, 1))
                Player1WonGamesSet2 = Match.GetPlayerSetScore(PlayerOrder.player1, 1);
            if (Player2WonGamesSet2 != Match.GetPlayerSetScore(PlayerOrder.player2, 1))
                Player2WonGamesSet2 = Match.GetPlayerSetScore(PlayerOrder.player2, 1);

            if (Player1WonGamesSet3 != Match.GetPlayerSetScore(PlayerOrder.player1, 2))
                Player1WonGamesSet3 = Match.GetPlayerSetScore(PlayerOrder.player1, 2);
            if (Player2WonGamesSet3 != Match.GetPlayerSetScore(PlayerOrder.player2, 2))
                Player2WonGamesSet3 = Match.GetPlayerSetScore(PlayerOrder.player2, 2);

            if (Player1WonGamesSet4 != Match.GetPlayerSetScore(PlayerOrder.player1, 3))
                Player1WonGamesSet4 = Match.GetPlayerSetScore(PlayerOrder.player1, 3);
            if (Player2WonGamesSet4 != Match.GetPlayerSetScore(PlayerOrder.player2, 3))
                Player2WonGamesSet4 = Match.GetPlayerSetScore(PlayerOrder.player2, 3);

            if (Player1WonGamesSet5 != Match.GetPlayerSetScore(PlayerOrder.player1, 4))
                Player1WonGamesSet5 = Match.GetPlayerSetScore(PlayerOrder.player1, 4);
            if (Player2WonGamesSet5 != Match.GetPlayerSetScore(PlayerOrder.player2, 4))
                Player2WonGamesSet5 = Match.GetPlayerSetScore(PlayerOrder.player2, 4);
        }
    }
}
