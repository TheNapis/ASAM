using System.Windows;
using System.Windows.Input;

namespace ASAM_Client.View.AuthMenu.PagePassword
{
    public partial class AuthentificationPage : System.Windows.Controls.UserControl
    {
        private string testedPassword;
        public int passerror = 0;
        private protected string Password = Properties.Settings.Default.password;
        public AuthentificationPage()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(System.Windows.Application.ResourceAssembly.Location);
            System.Windows.Application.Current.Shutdown();
        }


        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                VerifyPass();
            }
        }

        private void passwordBox1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            testedPassword = passwordBox1.Password;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            VerifyPass();
        }
        private void CloseAllWindows()
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter > 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }
        public void VerifyPass()
        {
            if (!string.IsNullOrEmpty(testedPassword))
            {
                if (passerror < 5)
                {
                    if (testedPassword == Password)
                    {
                        //Properties.Settings.Default.passState = 1;
                        //Properties.Settings.Default.Save();
                        MessageBox.Show("Bienvenue dans votre espace", "Réussite", MessageBoxButton.OK, MessageBoxImage.Information);
                        CloseAllWindows();
                        AdminMenu.MainAdminMenu adminMenu = new AdminMenu.MainAdminMenu();
                        adminMenu.Show();

                    }
                    else
                    {
                        passwordBox1.Clear();
                        MessageBox.Show("Mot de passe incorrect. Réessayer", "MDP Incorrect :(", MessageBoxButton.OK, MessageBoxImage.Error);
                        passerror++;
                    }

                }
                else
                {
                    PasswordFail window = new PasswordFail();
                    window.Show();
                }

            }
            else
            {
                MessageBox.Show("Veuillez renseigner un mot de passe.","Champ Vide", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
    }
}
