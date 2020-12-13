using MedGame.GameLogic;
using MedGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public partial class PlayWindow : Window
    {
        private MediaPlayer MediaPlayer { get; set; }
        bool isPlaying = false;

        public PlayWindow()
        {
            InitializeComponent();
            MediaPlayer = new MediaPlayer();

            string fileName = @"\media\level1d1.mp3";
            string fullFilename = GetApplicationRoot() + fileName;
            MediaPlayer.Open(new Uri(fullFilename));
        }

        private async void ButtonPlay_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RESTClient restClient = new RESTClient();

            if (isPlaying == false)
            {
                MediaPlayer.Play();
                isPlaying = true;
                
                GamePlay.StartMeditation();
            }
            else
            {
                MediaPlayer.Pause();
                isPlaying = false;
                GamePlay.StopMeditation(GamePlay.Player);
                await FileHandler.SavePlayerToFile(GamePlay.Player, GamePlay.Player.UserName);

                MessageBox.Show("Updated");
            }
        }

        public string GetApplicationRoot()
        {
            var exePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return appRoot;
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
