using System;
using System.Windows.Input;
using TennisMatch.UI.Command;
using TennisMatch.UI.Model;

namespace TennisMatch.UI.ViewModel
{
    public class RefereePanelViewModel
    {
        public SessionContext SessionContext { get; set; }
        public ICommand StartMatchCommand { get; set; }
        public ICommand AddPointCommand { get; set; }

        public RefereePanelViewModel(SessionContext sessionContext)
        {
            SessionContext = sessionContext;

            StartMatchCommand = new DelegateCommand(new Action<object>(StartMatch));
            AddPointCommand = new DelegateCommand(new Action<object>(AddPlayerPoint));
        }

        public void StartMatch(object obj)
        {
            SessionContext.StartMatch();
        }

        public void AddPlayerPoint(object obj)
        {
            SessionContext.AddPoint(obj.ToString());
        }
    }
}
