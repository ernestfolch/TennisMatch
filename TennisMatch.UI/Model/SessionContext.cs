using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TennisMatch.UI.Model
{
    public class SessionContext : INotifyPropertyChanged
    {
        private Match Match { get; set; }
        private string _player1Name;
        private string _player2Name;

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
