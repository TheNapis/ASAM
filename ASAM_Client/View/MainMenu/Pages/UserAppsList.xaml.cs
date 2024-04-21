using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ASAM_Client.View.MainMenu.Pages
{
    /// <summary>
    /// Logique d'interaction pour UserAppsList.xaml
    /// </summary>
    /// 
    public partial class UserAppsList : UserControl
    {
        static String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ASAMClientConfigurationData.mdf;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataSet ds;
        SqlDataReader reader;
        string ExecutablePath;
        

        public UserAppsList()
        {
            InitializeComponent();
            txtNameApp.Text = "";
            txtDescriptionApp.Text = "";
            FillList();
        }

        public void FillList()
        {
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand("SELECT * FROM AppList", con);
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adapter.Fill(ds, "Applist");
                Apps co = new Apps();
                IList<Apps> co1 = new List<Apps>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    co1.Add(new Apps
                    {
                        Id = Convert.ToInt32(dr[0].ToString()),
                        Name = dr[1].ToString(),
                        ImagePath = dr[2].ToString(),
                        ExePath = dr[3].ToString(),
                        Description = dr[4].ToString(),
                    });
                }
                LstAppsXAML.ItemsSource = co1;
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("ASAM rencontre une erreur critique. Code Erreur : Coin coin", "ASAM inutilisable", MessageBoxButton.OK,MessageBoxImage.Error);
                MessageBox.Show("ASAM étant inutilisable, le logiciel va fermer.", "ASAM inutilisable", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            finally
            {
                ds = null;
                adapter.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        public class Apps
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string ImagePath { get; set; }
            public string ExePath { get; set; }
            public string Description { get; set; }

        }

        private void LstAppsXAML_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            var apps = (Apps)item.SelectedItem;
            txtNameApp.Text = apps.Name;
            ImgApps.Source = new BitmapImage(new Uri(apps.ImagePath, UriKind.Relative));
            txtDescriptionApp.Text = apps.Description;
            btnEnter.Visibility = Visibility.Visible;
            ExecutablePath = apps.ExePath;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", ExecutablePath);
        }
    }
}