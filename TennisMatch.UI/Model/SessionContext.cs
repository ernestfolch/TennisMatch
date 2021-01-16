using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TennisMatch.UI.Model
{
    public class SessionContext : INotifyPropertyChanged
    {
        private Match Match { get; set; }
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
        public string Player1GameScore
        {
            get
            {
                return (Match != null) ? Match.GetPlayerGameScore(PlayerOrder.player1) : "0";
            }
        }
        public string Player2GameScore
        {
            get
            {
                return (Match != null) ? Match.GetPlayerGameScore(PlayerOrder.player2) : "0";
            }
        }

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
            }
        }
    }
}
