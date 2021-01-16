using TennisMatch.UI.Model;

namespace TennisMatch.UI.ViewModel
{
    public class RefereePanelViewModel
    {
        public SessionContext SessionContext { get; set; }

        public RefereePanelViewModel(SessionContext sessionContext)
        {
            SessionContext = sessionContext;
        }
    }
}
