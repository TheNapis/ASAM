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

namespace ASAM_Client.View.AuthMenu
{
    /// <summary>
    /// Logique d'interaction pour PasswordFail.xaml
    /// </summary>
    public partial class PasswordFail : Window
    {
        public PasswordFail()
        {
            InitializeComponent();
        }
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ShutdownViews.NormalRestart page = new ShutdownViews.NormalRestart();
            page.Show();
        }
    }
}
