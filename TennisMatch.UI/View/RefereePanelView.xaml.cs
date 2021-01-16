using System.Windows;
using TennisMatch.UI.Model;
using TennisMatch.UI.ViewModel;

namespace TennisMatch.UI.View
{
    /// <summary>
    /// Interaction logic for RefereePanelView.xaml
    /// </summary>
    public partial class RefereePanelView : Window
    {
        public RefereePanelView(SessionContext sessionContext)
        {
            InitializeComponent();

            var refereePanelViewModel = new RefereePanelViewModel(sessionContext);
            DataContext = refereePanelViewModel;
        }
    }
}
