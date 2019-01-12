using MedGame.GameLogic;
using MedGame.Services;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace MedGame.UI.WPF
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        MainWindow MainWindow { get; set; }
        private MediaPlayer MediaPlayer { get; set; }
        bool isPlaying = false;

        DispatcherTimer Timer { get; set; }

        public GameWindow()
        {
            InitializeComponent();

            LabelPoints.Content = Game.Player.Points;


            Timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(1000)
            };

            Timer.Tick += Timer_Tick;
            MediaPlayer = new MediaPlayer();

            string fileName = @"\media\level1d1.mp3";
            string fullFilename = GetApplicationRoot() + fileName;
            MediaPlayer.Open(new Uri(fullFilename));
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateUI();
        }


        private async void ImageButtonPlay_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RESTClient restClient = new RESTClient();

            if (isPlaying == false)
            {
                MediaPlayer.Play();
                isPlaying = true;
                Timer.Start();
                Game.StartMeditation();
            }
            else
            {
                MediaPlayer.Pause();
                Timer.Stop();
                isPlaying = false;
                Game.StopMeditation();
                
                await restClient.Update(Game.Player);
            }

            UpdateUI();
        }

        private void UpdateUI()
        {
            double positionNow = MediaPlayer.Position.Seconds;
            double totalLengthOfAudio = MediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            double processInProcentage = positionNow / totalLengthOfAudio;
            ProgressBar.Value = processInProcentage * 1000;

            LabelPoints.Content = Game.Player.Points;
            LabelLevel.Content = Game.Player.Level;
        }


        public string GetApplicationRoot()
        {
            var exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return appRoot;
        }

        private void ToTamagotchiWindowButton_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TamagotchiWindow TamagotchiWindow = new TamagotchiWindow();
            TamagotchiWindow.Show();
            this.Close();
        }
    }
}
