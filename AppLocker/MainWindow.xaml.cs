using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Microsoft.Win32;

namespace AppLocker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                MainInfo.Text += $"Key: {key}\n";
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    MainInfo.Text += $"Subkey: {subkey_name}\n";
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        MainInfo.Text += $"Content: {subkey.GetValue("DisplayName")}\n";
                    }
                }
            }
        }

        private void GetProcesses_Click(object sender, RoutedEventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                if (!String.IsNullOrEmpty(p.ProcessName))
                {
                    MainInfo.Text += p.ProcessName + "\n";
                }
            }
        }
    }   
}
