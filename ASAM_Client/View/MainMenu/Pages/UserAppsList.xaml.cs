using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Data.SQLite;
using System.Diagnostics;
using ASAM_Client.Model;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Markup;

namespace ASAM_Client.View.MainMenu.Pages
{
    /// <summary>
    /// Logique d'interaction pour UserAppsList.xaml
    /// </summary>
    /// 
    public partial class UserAppsList : UserControl
    {
        static String connectionString = @"Data Source=C:\ASAM\ASAM_Client\ASAMClientConfigurationData.sqlite; Version = 3; New = True; Compress = True;";
        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataAdapter adapter;
        DataSet ds;
        SQLiteDataReader reader;
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
                ErrorView.ErrorView view = new ErrorView.ErrorView();
                view.ShowDialog();
                view.Topmost = true;

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