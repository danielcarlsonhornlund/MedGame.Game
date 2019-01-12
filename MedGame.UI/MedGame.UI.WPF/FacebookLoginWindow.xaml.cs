using MedGame.GameLogic;
using MedGame.Models;
using MedGame.Services;
using mshtml;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedGame.UI.WPF
{
    /// <summary>
    /// Interaction logic for FacebookLoginWindow.xaml
    /// </summary>
    public partial class FacebookLoginWindow : Window
    {
        public FacebookLoginWindow()
        {
            InitializeComponent();

            WebBrowser1.Navigate(RESTClient.UrlFacebook);

            WebBrowser1.Margin = new Thickness(-190, -100, -230, 0);
            WebBrowser1.Width = 800;
            WebBrowser1.Height = 340;


            FaceBookLoginWindow.Width = 400;
            FaceBookLoginWindow.Height = 130;

        }

        private void WebBrowser1_Navigated(object sender, NavigationEventArgs e)
        {
            if (WebBrowser1.Source.ToString().Contains("signinexternal"))
            {
                dynamic doc = WebBrowser1.Document;
                string playerFromFacebook = doc.documentElement.InnerHtml;

                playerFromFacebook = playerFromFacebook.Substring(26, playerFromFacebook.Length - 39);

                Game.Player = JsonConvert.DeserializeObject<Player>(playerFromFacebook);
                this.Close();
            }
        }

        private void WebBrowser1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void wb_LoadCompleted(object sender, NavigationEventArgs e)
        {
            mshtml.IHTMLDocument2 dom = (mshtml.IHTMLDocument2)WebBrowser1.Document;
            dom.body.style.overflow = "hidden";

            WebBrowser1.Refresh(true);

        }
    }
}
