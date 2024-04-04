using System.Runtime.InteropServices;
using System.Windows;

namespace ASAM_Client.View.AdminMenu.Pages
{
    /// <summary>
    /// Logique d'interaction pour PCInfos.xaml
    /// </summary>
    public partial class PCInfos : Window
    {
        public PCInfos()
        {
            InitializeComponent();
            txtOSVer.Text = "Version du système : "+ RuntimeInformation.OSDescription;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
