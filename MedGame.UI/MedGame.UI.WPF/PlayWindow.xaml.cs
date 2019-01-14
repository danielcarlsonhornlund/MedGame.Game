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
                
                Game.StartMeditation();
            }
            else
            {
                MediaPlayer.Pause();
                isPlaying = false;
                Game.StopMeditation();
                var player = await restClient.Update(Game.Player);

                MessageBox.Show(player.PlayerMessage);
            }
        }

        public string GetApplicationRoot()
        {
            var exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return appRoot;
        }

        private void IconPlay_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MunkWindow munkWindow = new MunkWindow();
            munkWindow.Show();
            this.Close();
        }
    }
}
