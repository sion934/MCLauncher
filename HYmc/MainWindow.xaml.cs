using System;
using System.Collections.Generic;
using System.IO;
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
using System.Drawing;
using System.Data;
using System.ComponentModel;


namespace HYmc
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (File.Exists(@".minecraft\TenProtect\TenSafe.exe"))
            {
                System.Diagnostics.Process.Start(@".minecraft\TenProtect\TenSafe.exe");
            }
            else
            {
                MessageBox.Show("游戏文件损坏请重新安装");
            }
            if (File.Exists(@"HYMCL.exe"))
            {
                System.Diagnostics.Process.Start(@"HYMCL.exe");
            }
            else
            {
                MessageBox.Show("游戏文件损坏请重新安装");
            }
            App.Current.Shutdown();
            //try
            //{
            //读取版本
            //listBox1.Items.Clear();
            //String[] vers = Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory + "\\.minecraft\\versions");
            //foreach (String item0 in vers)
            //{
            //listBox1.Items.Add(item0.Replace(AppDomain.CurrentDomain.BaseDirectory + "\\.minecraft\\versions\\", ""));
            //}
            //}
            //catch (Exception)
            //{

            //throw;
            //}
         }

            private void button_Click(object sender, RoutedEventArgs e)
            {

            //System.Diagnostics.Process.Start(@"hymclauncher.exe");
            //App.Current.Shutdown();
            //启动
            //String[] TCfg = new String[3];
            //TCfg = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\HYMCLConfig.HYMCLConfig");//读取配置
            //Launcher launcher = new Launcher();
            //if (listBox1.SelectedIndex == -1)
            //{
            //    listBox1.SelectedIndex = 0;
            //}
            //launcher.Launch(TCfg[0], TCfg[1], TCfg[2], listBox1.SelectedItem.ToString());

           }

            private void button1_Click(object sender, RoutedEventArgs e)
            {
            //System.Diagnostics.Process.Start(@".minecraft\resourcepacks\");
            }

            private void button2_Click(object sender, RoutedEventArgs e)
            {
            //System.Diagnostics.Process.Start(@".minecraft\shaderpacks\");
            }

            private void button3_Click(object sender, RoutedEventArgs e)
            {
            //MessageBox.Show("测试功能", "警告");

            //Window1 s = new Window1();
            //s.LoadForm();
            //s.Show();
            }
        }
    }
