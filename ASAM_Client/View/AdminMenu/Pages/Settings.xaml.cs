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

        string ActualPassword;
        string NewPassword;
        string RetypedNewPassword;
        bool ChangePassword = false;

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
            VerifyNewPassword();
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
            if (ChangePassword == true)
            {
                Properties.Settings.Default.password = NewPassword;
            }
            Properties.Settings.Default.Save();
        }
        private void VerifyNewPassword()
        {
            if (!string.IsNullOrEmpty(ActualPassword))
            {
                if (ActualPassword == Properties.Settings.Default.password)
                {
                    if (!string.IsNullOrEmpty(NewPassword) & !string.IsNullOrEmpty(NewPassword))
                    {
                        if (NewPassword == RetypedNewPassword)
                        {
                            ChangePassword = true;
                            MessageBox.Show("Le nouveau mot de passe est conforme.\n\rSi vous avez modifié que le mot de passe,\n\r" +
                                "vous pouvez ignorer les messages qui suivent.");
                        }
                        else { MessageBox.Show("Les nouveaux mots de passe ne correspndent pas.", "Mot de passe non valide"); }

                    }
                    else { MessageBox.Show("Les nouveaux mots de passe ne correspndent pas ou sont non renseignés.", "Mot de passe non valide"); }

                }else { MessageBox.Show("Le mot de passe actuel n'est pas bon.", "Mot de passe incorrect"); }
                
            }
            else
            {
                MessageBox.Show("Le mot de passe ne sera pas changé.", "Mot de passe inchangé");
            }
        }

        private void txtNewPasswordRetyped_TextChanged(object sender, TextChangedEventArgs e)
        {
            RetypedNewPassword = txtNewPasswordRetyped.Text;
        }


        private void txtNewPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            NewPassword = txtNewPassword.Text;
        }

        private void txtActualPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ActualPassword = txtActualPassword.Password;
        }
    }
}
