using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ASAM_Client.View.ShutdownViews
{
    /// <summary>
    /// Logique d'interaction pour NormalRestart.xaml
    /// </summary>
    public partial class NormalRestart : Window
    {
        public NormalRestart()
        {
            InitializeComponent();
            MyFadingText.Text = "Redémarrage en cours...";
            DispatcherTimer t1 = new DispatcherTimer();
            t1.Interval = TimeSpan.FromSeconds(7);
            t1.Tick += timer_Tick;
            t1.Start();

            ColorAnimation animation;
            animation = new ColorAnimation();
            animation.From = System.Windows.Media.Color.FromArgb(255, 46, 117, 216);
            animation.To = Colors.Black;
            animation.Duration = new Duration(TimeSpan.FromSeconds(1));
            window.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);


        }
        void timer_Tick(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/r /t 0");
        }
    }
}
