using System.Windows;
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

            // open the referee and scoreboard windows at the same time
            var refereePanel = new RefereePanelView();
            var scoreboardPanel = new ScoreboardView();

            refereePanel.Show();
            scoreboardPanel.Show();
        }
    }
}
