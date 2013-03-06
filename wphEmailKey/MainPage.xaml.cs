using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace wphEmailKey
{
    public partial class MainPage : PhoneApplicationPage
    {
        string key = @"Software\Microsoft\FingerKB\AlternateMappings\{805d58c2-096a-4451-b2cb-40996fcb236d}";

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            if (WP7RootToolsSDK.Environment.HasRootAccess() != true)
            {
                MessageBox.Show("This application requires root access.\nMake sure you mark this app as Trusted in Root Tools");
            }
        }

        private void TextBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            if (tbEmail.Text == "email address")
            {
                tbEmail.Text = "";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            resetEmailkey();
            WP7RootToolsSDK.Registry.SetMultiStringValue(WP7RootToolsSDK.RegistryHyve.LocalMachine, key, "@", new string[] { tbEmail.Text });
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            resetEmailkey();
        }

        void resetEmailkey()
        {
            try
            {
                WP7RootToolsSDK.Registry.DeleteValue(WP7RootToolsSDK.RegistryHyve.LocalMachine, key, "@");
            }
            catch
            {
            }
        }
    }
}