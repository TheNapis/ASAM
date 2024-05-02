using ASAM_Client.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ASAM_Client.View.MainMenu.Pages
{
    /// <summary>
    /// Logique d'interaction pour UserAppsList.xaml
    /// </summary>
    /// 
    public partial class UserAppsList : UserControl
    {
        static String connectionString = Properties.Settings.Default.ACCDPath;
        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataAdapter adapter;
        DataSet ds;
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
                con = new SQLiteConnection(connectionString);
                con.Open();
                cmd = new SQLiteCommand("SELECT * FROM AppList", con);
                adapter = new SQLiteDataAdapter(cmd);
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
                MainFunctions.Logger(ex.Message);
                if (Properties.Settings.Default.ErrorLevelAppList == false)
                {
                    ErrorView.ErrorView view = new ErrorView.ErrorView();
                    view.ShowDialog();
                    view.Topmost = true;
                }
                else if (Properties.Settings.Default.ErrorLevelAppList == true)
                {
                    txtNameApp.Text = "Échec du chargement";
                    txtDescriptionApp.Text = "La liste d'application n'a pu être chargée\r\nCode d'erreur : Caneton";
                    LstAppsXAML.Background = Brushes.DarkGray;
                }
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
            try
            {
                Process.Start(ExecutablePath);
            }
            catch
            {
                try
                {
                    Process.Start("explorer.exe",ExecutablePath);
                }
                catch(Exception ex)
                {
                    MainFunctions.Logger(ex.Message);
                    MessageBox.Show("Cette application semble avoir un problème. Code d'erreur : ", "Erreur");
                }
                
            }
            
        }
    }
}