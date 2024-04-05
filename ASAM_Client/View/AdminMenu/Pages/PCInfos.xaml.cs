using System;
using System.Linq;
using System.IO;
using System.Management;
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
            txtName.Text = "Nom du PC : " + System.Environment.MachineName;
            DriveInfo dInfo = new DriveInfo("C");
            float space = dInfo.AvailableFreeSpace;
            space = ((space/1024)/1024)/1024;
            txtSpaceDisk.Text = "Espace disque disponible : " + space + " Go";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
