using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace ASAM_Master
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            timeTb.Text = DateTime.Now.ToString("HH:mm");
            dateTb.Text = DateTime.Now.ToString("D");
        }

        private void btn_Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_Quit_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            quitIcon.PrimaryColor = System.Windows.Media.Brushes.IndianRed;
        }

        private void btn_Quit_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (System.Windows.Media.Brush)converter.ConvertFromString("#0044a3");
            quitIcon.PrimaryColor = brush;
        }
    }
}
