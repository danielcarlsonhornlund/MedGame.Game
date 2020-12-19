using System.Windows;
using System.Windows.Input;

namespace MedGame.UI.WPF
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class StatisticsWindow : Window
    {
        public StatisticsWindow()
        {
            InitializeComponent();
        }
        private void IconPlay_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PlayWindow playWindow = new PlayWindow();
            playWindow.Show();
            this.Close();
        }

        private void IconMunk_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MunkWindow MunkWindow = new MunkWindow();
            MunkWindow.Show();
            this.Close();
        }

        private void IconStatistics_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            StatisticsWindow StatisticsWindow = new StatisticsWindow();
            StatisticsWindow.Show();
            this.Close();
        }

        private void IconShare_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ShareWindow ShareWindow = new ShareWindow();
            ShareWindow.Show();
            this.Close();
        }

        private void IconSettings_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SettingsWindow SettingsWindow = new SettingsWindow();
            SettingsWindow.Show();
            this.Close();
        }
    }
}
