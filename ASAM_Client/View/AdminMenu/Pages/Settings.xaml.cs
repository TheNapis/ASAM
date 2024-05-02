using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace ASAM_Client.View.AdminMenu.Pages
{
    /// <summary>
    /// Logique d'interaction pour Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        string NewConnChain;
        bool NewErrorLevelAppList;
        public Settings()
        {
            InitializeComponent();
            txtConnChain.Text = Properties.Settings.Default.ACCDPath;
            if (Properties.Settings.Default.ErrorLevelAppList == true)
            {
                cbmBoxConnChain.SelectedItem = Yes_ITEM;
            }
            else if (Properties.Settings.Default.ErrorLevelAppList == false)
            {
                cbmBoxConnChain.SelectedItem = No_ITEM;
            }
        }

        private void btnValidate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("MODIFIER CES PARAMETRES PEUVENT AVOIR UN IMPACT SUR ASAM\n\rNOTAMMENT SI ILS SONT MAL REGLES !");
            var result = MessageBox.Show("Voulez-vous enregistrer ces paramètres ?","ATTENTION",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                validateAllChangement();
                var result2 = MessageBox.Show("Les paramètres ont été modifiés. Redémarrer ASAM Client ?", "Paramètres modifiés", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result2 == MessageBoxResult.Yes)
                {
                    Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
                else { this.Close(); }
            }
            else { }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtConnChain_TextChanged(object sender, TextChangedEventArgs e)
        {
            NewConnChain = txtConnChain.Text;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbmBoxConnChain.SelectedItem == Yes_ITEM)
            {
                NewErrorLevelAppList = true;
            }
            else if (cbmBoxConnChain.SelectedItem == No_ITEM)
            {
                NewErrorLevelAppList = false;
            }
        }


        private void validateAllChangement()
        {
            Properties.Settings.Default.ACCDPath = NewConnChain;
            Properties.Settings.Default.ErrorLevelAppList = NewErrorLevelAppList;
            Properties.Settings.Default.Save();
        }
    }
}
