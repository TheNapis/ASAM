using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ASAM_Client.View.ErrorView
{
    /// <summary>
    /// Logique d'interaction pour OrientationError.xaml
    /// </summary>
    public partial class OrientationError : Window
    {
        public OrientationError()
        {
            InitializeComponent();
            DispatcherTimer orientationCkeck = new DispatcherTimer();
            orientationCkeck.Interval = TimeSpan.FromSeconds(1);
            orientationCkeck.Tick += timer_Tick;
            orientationCkeck.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            var orientation = SystemInformation.ScreenOrientation;
            if (orientation == ScreenOrientation.Angle0)
            {
                this.Close();
            }
        }
    }
}
