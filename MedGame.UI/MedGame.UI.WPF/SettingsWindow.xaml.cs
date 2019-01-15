using MedGame.GameLogic;
using MedGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MedGame.UI.WPF
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
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
