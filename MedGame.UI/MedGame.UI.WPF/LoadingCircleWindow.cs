using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedGame.UI.WPF
{
    public partial class LoadingCircleWindow: Form
    {
        private static bool isShown = false;
        public static Timer timer = new Timer();

        public LoadingCircleWindow()
        {
            InitializeComponent();

            timer.Interval = 1;
            timer.Tick += Timer_Tick;

            
        }

        public new static void Show()
        {
            isShown = true;
        }

        public new static void Hide()
        {
            isShown = false;
        }

        private void LoadingCircle_Load(object sender, EventArgs e)
        {
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (isShown == false)
            {
                this.Visible = false;
            }
            else
            {
                this.Visible = true;
            }
        }
    }
}
