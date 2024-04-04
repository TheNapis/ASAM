using System.Diagnostics;
using System.Windows;

namespace ASAM_Client.View.MainMenu.Pages
{
    /// <summary>
    /// Logique d'interaction pour UserApps.xaml
    /// </summary>
    public partial class UserApps : System.Windows.Controls.UserControl
    {
        public UserApps()
        {
            InitializeComponent();
        }

        private void btnWriter_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\LibreOffice 6.3\LibreOffice Writer.lnk");
        }

        private void btnPresentation_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\LibreOffice 6.3\LibreOffice Impress.lnk");
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\LibreOffice 6.3\LibreOffice Calc.lnk");
        }

        private void btnScratch_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Scratch 3.lnk");

        }

        private void btnInternet_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Microsoft Edge.lnk");
        }

        private void btnGlobe_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Google Earth Pro.lnk");
        }

        private void btnGIMP_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\GIMP 2.10.34.lnk");
        }

        private void btnVocal_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", @"shell:appsFolder\Microsoft.WindowsSoundRecorder_8wekyb3d8bbwe!App");
        }

        private void btnCalculatrice_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("calc");
        }
    }
}
