using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ASAM_Client.View.AdminMenu.Pages
{
    /// <summary>
    /// Logique d'interaction pour AboutASAM.xaml
    /// </summary>
    public partial class AboutASAM : Window
    {
        public AboutASAM()
        {
            InitializeComponent();
            txt_Composante.Text = "Composante : " + Properties.Settings.Default.Composante;
            txt_Version.Text = "Version : " + Properties.Settings.Default.Version;
            txt_DateVersion.Text = "Date de la version : " + Properties.Settings.Default.DatedeVersion;
            txt_VersionPourAnnee.Text = "Version pour les années : " + Properties.Settings.Default.VersionPourAnnes;

        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
