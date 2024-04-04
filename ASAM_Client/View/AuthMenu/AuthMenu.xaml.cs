using ASAM_Client.View.AuthMenu.PagePassword;
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
    /// Logique d'interaction pour AuthMenu.xaml
    /// </summary>
    public partial class AuthMenu : Window
    {
        public AuthMenu()
        {
            InitializeComponent();
            PagePassword.AuthentificationPage authPage = new AuthentificationPage();
            Content = authPage;

        }
    }
}
