using ASAM_Client.Model;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;

namespace ASAM_Client.View.AdminMenu.Pages
{
    /// <summary>
    /// Logique d'interaction pour PCState.xaml
    /// </summary>
    public partial class PCState : Window
    {
        public PCState()
        {
            InitializeComponent();
            LASTDATE.Text = Properties.Settings.Default.LastStateDate.ToShortDateString() + "  " + Properties.Settings.Default.LastStateDate.ToShortTimeString();
            if (Properties.Settings.Default.PCState == true)
            {
                IconSTATUS.PrimaryColor = Brushes.PaleGreen;
                LASTSTATUS.Text = "Opérationnel";
            }
            else 
            {
                IconSTATUS.PrimaryColor = Brushes.OrangeRed;
                LASTSTATUS.Text = Properties.Settings.Default.LastStatus;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnValid_Click(object sender, RoutedEventArgs e)
        {
            if (RB_NOTOK.IsChecked == true & CB_Reason.SelectedItem == null)
            {
                MessageBox.Show("Vous devez sélectionner une raison.");
            }
            else if (RB_NOTOK.IsChecked == false & RB_OK.IsChecked == false)
            {
                MessageBox.Show("Vous devez sélectionner un état.");
            }
            else 
            {
                var question = MessageBox.Show("Voulez-vous validez ces changements ?", "Dernières vérifications", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (question == MessageBoxResult.Yes)
                {
                    if (RB_OK.IsChecked == true)
                    {
                        Properties.Settings.Default.PCState = true;
                        Properties.Settings.Default.LastStatus = "Opérationnel";
                        Properties.Settings.Default.LastStateDate = System.DateTime.Now;
                        Properties.Settings.Default.Save();
                        MainFunctions.StatusLogger("L'état du PC à changé pour : " + Properties.Settings.Default.PCState + ", pour la raison : " + Properties.Settings.Default.LastStatus + " .");
                        MessageBox.Show("État du PC changé !");
                        this.Close();
                    }
                    else
                    {
                        Properties.Settings.Default.PCState = false;
                        Properties.Settings.Default.LastStatus = CB_Reason.SelectedItem.ToString();
                        Properties.Settings.Default.LastStatus = Properties.Settings.Default.LastStatus.Substring(38);
                        Properties.Settings.Default.LastStateDate = System.DateTime.Now;
                        Properties.Settings.Default.Save();


                        MainFunctions.StatusLogger("L'état du PC à changé pour : " + Properties.Settings.Default.PCState + ", pour la raison : " + Properties.Settings.Default.LastStatus + " .");
                        MessageBox.Show("État du PC changé !");
                        this.Close();
                    }
                }
            }

            
        }
    }
}
