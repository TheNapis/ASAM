using System.Windows;

namespace ASAM_Client.View.ErrorView
{
    public partial class ErrorView : Window
    {
        public ErrorView()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Le contenu de l'erreur est disponible dans le dossier : C:\\ASAM\\Logs\\", "ASAM inutilisable");
            Application.Current.Shutdown();
        }

    }
}
