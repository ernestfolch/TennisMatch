using System.Windows;
using TennisMatch.UI.Model;
using TennisMatch.UI.View;

namespace TennisMatch.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // generate the shared session context
            var sessionContext = new SessionContext();

            // open the referee and scoreboard windows at the same time (using Dependency Injection pattern)
            var refereePanel = new RefereePanelView(sessionContext);
            var scoreboardPanel = new ScoreboardView(sessionContext);

            refereePanel.Show();
            scoreboardPanel.Show();
        }
    }
}
