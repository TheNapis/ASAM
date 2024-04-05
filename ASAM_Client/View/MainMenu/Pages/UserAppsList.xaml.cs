using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Markup;

namespace ASAM_Client.View.MainMenu.Pages
{
    /// <summary>
    /// Logique d'interaction pour UserAppsList.xaml
    /// </summary>
    public partial class UserAppsList : UserControl
    {
        public UserAppsList()
        {
            InitializeComponent();
            Appslist.Items.Add("LibreOffice Texte");
            Appslist.Items.Add("Navigateur internet");
            Appslist.Items.Add("VLC Video et Musique");
            Appslist.Items.Add("LibreOffice Tableur");
            Appslist.Items.Add("LibreOffice Presentation");
        }
    }
}