﻿using ASAM_Client.View.ErrorView;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Threading;

namespace ASAM_Client.View.MainMenu
{
    /// <summary>
    /// Logique d'interaction pour MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window 
    {
        public MainMenu()
        {
            logo = Properties.Settings.Default.logo;
            Mylogo = logo;
            if (Properties.Settings.Default.PCState == false)
            {
                System.Windows.MessageBox.Show("Bonjour,\n\rcet ordinateur est en panne.\n\rPour la raison : " + Properties.Settings.Default.LastStatus + " .", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();

            DispatcherTimer LiveBattery = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(5);
            LiveTime.Tick += timer2_Tick;
            LiveTime.Start();

            InitializeComponent();
            GetBatteryPercentage();
            VerifyInternet();
            
        }
        public void AppsPage()
        {
            MainGrid.Children.Clear();
            Pages.UserAppsList usercontrol = new Pages.UserAppsList();
            MainGrid.Children.Add(usercontrol);
        }

        public void HelpPage()
        {
            MainGrid.Children.Clear();
            Pages.HelpPage usercontrol = new Pages.HelpPage();
            MainGrid.Children.Add(usercontrol);
        }

        public int adminCount = 0;

        bool message3 = false;
        bool message4 = false;

        
        void timer_Tick(object sender, EventArgs e)
        {
            timeTb.Text = DateTime.Now.ToString("HH:mm");
            dateTb.Text = DateTime.Now.ToString("D");
        }
        void timer2_Tick(object sender, EventArgs e)
        {
            GetBatteryPercentage();
            VerifyInternet();
            var orientation = SystemInformation.ScreenOrientation;
            if (orientation != ScreenOrientation.Angle0)
            {
                OrientationError page = new OrientationError();
                page.ShowDialog();
            }

        }
        
        void VerifyInternet()
        {
            try
            {
                var h = Dns.GetHostEntry("www.google.com");
                ICON2.PrimaryColor = Brushes.PaleGreen;
            }
            catch (SocketException)
            {
                ICON2.PrimaryColor = Brushes.Red;
            }
        }

        private void btnShutdown_Click(object sender, RoutedEventArgs e)
        {
            var result = System.Windows.MessageBox.Show("Voulez-vous éteindre l'ordinateur ?", "Extinction", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ShutdownViews.NormalShutdown shutdown = new ShutdownViews.NormalShutdown();
                shutdown.Show();
            }
            else { }

        }
        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Pages.HelpPage usercontrol = new Pages.HelpPage();
            MainGrid.Children.Add(usercontrol);
        }
        private void btnApps_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Pages.UserAppsList usercontrol = new Pages.UserAppsList();
            MainGrid.Children.Add(usercontrol);
        }

        private void btnBattery_Click(object sender, RoutedEventArgs e)
        {
            if (adminCount >= 10)
            {
                MainMenu menu = new MainMenu();
                menu.WindowState = WindowState.Minimized;
                AuthMenu.AuthMenu page = new AuthMenu.AuthMenu();
                page.ShowDialog();
                window.WindowState = WindowState.Minimized;

                adminCount = 0;
            }
            else
            {
                adminCount = adminCount + 1;
            }
        }


        

        private void btnFolder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(@"C:\Users\Eleves\Desktop");
            }
            catch (System.ComponentModel.Win32Exception)
            {
                string message = "Le chemin d'accès pour le dossier C:\\Users\\Eleves\\Desktop est inacessible.\nCode erreur : Patte de canard";
                string title = "Contacter votre enseignant";
                System.Windows.MessageBox.Show(message, title);
            }
        }

        private void GetBatteryPercentage()
        {

            System.Management.ManagementClass wmi = new System.Management.ManagementClass("Win32_Battery");
            var allBatteries = wmi.GetInstances();

            foreach (var battery in allBatteries)
            {
                PowerStatus pwr = SystemInformation.PowerStatus;


                int estimatedChargeRemaining = Convert.ToInt32(battery["EstimatedChargeRemaining"]);
                switch (pwr.PowerLineStatus)
                {
                    case (System.Windows.Forms.PowerLineStatus.Offline):

                        ICON1.Rotation = 0;
                        if (estimatedChargeRemaining >= 75)
                        {
                            ICON1.Icon = FontAwesome6.EFontAwesomeIcon.Solid_BatteryFull;
                            ICON1.PrimaryColor = Brushes.PaleGreen;
                        }
                        else if (estimatedChargeRemaining >= 50)
                        {
                            ICON1.Icon = FontAwesome6.EFontAwesomeIcon.Solid_BatteryThreeQuarters;
                            ICON1.PrimaryColor = Brushes.White;

                        }
                        else if (estimatedChargeRemaining >= 25)
                        {
                            ICON1.Icon = FontAwesome6.EFontAwesomeIcon.Solid_BatteryHalf;
                            ICON1.PrimaryColor = Brushes.Orange;

                        }
                        else if (estimatedChargeRemaining >= 15)
                        {
                            ICON1.Icon = FontAwesome6.EFontAwesomeIcon.Solid_BatteryQuarter;
                            ICON1.PrimaryColor = Brushes.Red;


                        }
                        else if (estimatedChargeRemaining >= 8)
                        {
                            ICON1.Icon = FontAwesome6.EFontAwesomeIcon.Solid_BatteryEmpty;
                            ICON1.PrimaryColor = Brushes.Red;

                            if (message4 == false)
                            {
                                System.Windows.MessageBox.Show("La batterie de l'ordinateur est très faible. L'ordinateur va maintenant s'éteindre.", "Arrêt de l'ordinateur", MessageBoxButton.OK, MessageBoxImage.Error);
                                Process.Start("shutdown", "/s /t 0");
                                message4 = true;
                            }
                            else { }
                        }
                        else
                        {
                            ICON1.Icon = FontAwesome6.EFontAwesomeIcon.Solid_Plug;
                        }
                        break;

                    case (System.Windows.Forms.PowerLineStatus.Online):

                        ICON1.Rotation = 90;
                        ICON1.Icon = FontAwesome6.EFontAwesomeIcon.Solid_Plug;
                        if (estimatedChargeRemaining >= 90)
                        {
                            ICON1.PrimaryColor = Brushes.PaleGreen;
                        }
                        else
                        {
                            ICON1.PrimaryColor = Brushes.Orange;
                        }
                        break;
                }


            }
        }

        private string logo;

        public string Mylogo
        {
            get { return logo; }
            set { logo = value; }
        }



    }
}
