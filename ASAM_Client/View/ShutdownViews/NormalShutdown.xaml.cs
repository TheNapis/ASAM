using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace ASAM_Client.View.ShutdownViews
{
    /// <summary>
    /// Logique d'interaction pour NormalShutdown.xaml
    /// </summary>
    public partial class NormalShutdown : Window
    {
        public NormalShutdown()
        {
            InitializeComponent();
            MyFadingText.Text = "Arrêt en cours...";
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
            Process.Start("shutdown", "/s /t 0");
        }
    }
}
