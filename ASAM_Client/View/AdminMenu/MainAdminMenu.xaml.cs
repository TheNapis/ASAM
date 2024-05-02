using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Diagnostics;

namespace ASAM_Client.View.AdminMenu
{
    
    public partial class MainAdminMenu : Window
    {
        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        public MainAdminMenu()
        {
            InitializeComponent();
        }

        private void btnInfoPC_Click(object sender, RoutedEventArgs e)
        {
            Pages.PCInfos pCInfos = new Pages.PCInfos();
            pCInfos.ShowDialog();
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
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Vous allez quittez l'espace réservé.", "Quitter l'espace réservé",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
        }
        private void btnSeission_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Voulez vous vraiment fermer la seission : " + Environment.UserName + " ? ", "Fermer la session", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ExitWindowsEx(0, 0);
            }
        }
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            Pages.AboutASAM page = new Pages.AboutASAM();
            page.ShowDialog();
        }
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Pages.Settings page = new Pages.Settings();
            page.ShowDialog();
        }
    }
}
