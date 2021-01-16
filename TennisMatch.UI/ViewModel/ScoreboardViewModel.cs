using TennisMatch.UI.Model;

namespace TennisMatch.UI.ViewModel
{
    public class ScoreboardViewModel
    {
        public SessionContext SessionContext { get; set; }

        public ScoreboardViewModel(SessionContext sessionContext)
        {
            SessionContext = sessionContext;
        }
    }
}