using System.Windows;
using TennisMatch.UI.Model;
using TennisMatch.UI.ViewModel;

namespace TennisMatch.UI.View
{
    /// <summary>
    /// Interaction logic for ScoreboardView.xaml
    /// </summary>
    public partial class ScoreboardView : Window
    {
        public ScoreboardView(SessionContext sessionContext)
        {
            InitializeComponent();

            var scoreboardViewModel = new ScoreboardViewModel(sessionContext);
            DataContext = scoreboardViewModel;
        }
    }
}
