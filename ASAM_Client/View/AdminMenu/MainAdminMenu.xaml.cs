using System.Windows;

namespace ASAM_Client.View.AdminMenu
{
    /// <summary>
    /// Logique d'interaction pour MainAdminMenu.xaml
    /// </summary>
    public partial class MainAdminMenu : Window
    {
        public MainAdminMenu()
        {
            InitializeComponent();
        }

        private void btnInfoPC_Click(object sender, RoutedEventArgs e)
        {
            Pages.PCInfos pCInfos = new Pages.PCInfos();
            pCInfos.ShowDialog();
        }

        private void btnStatus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEteindre_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Voulez vous vraiment éteindre ce PC ?", "Eteindre",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ShutdownViews.NormalShutdown normalShutdown = new ShutdownViews.NormalShutdown();
                normalShutdown.ShowDialog();
            }
            else { }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Voulez vous vraiment quitter ASAM ? " + " Le client se relancera si le PC est redémarré.", "Quitter ASAM Client", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {

            }

            
        }
        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Voulez vous vraiment redémarrer ce PC ?", "Redémarrer", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ShutdownViews.NormalRestart normalRestart = new ShutdownViews.NormalRestart();
                normalRestart.ShowDialog();
            }
            else { }
        }
    }
}
