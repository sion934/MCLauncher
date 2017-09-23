using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace HYmc
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void LoadForm()
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\HYMCLConfig.HYMCLConfig"))
            {
                String[] js = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\JavaSoft\Java Runtime Environment").GetSubKeyNames();//读取jre路径。
                StreamWriter sw = File.CreateText(AppDomain.CurrentDomain.BaseDirectory + "\\HYMCLConfig.HYMCLConfig");
                sw.Write("1024\n" + Registry.LocalMachine.OpenSubKey(@"SOFTWARE\JavaSoft\Java Runtime Environment\" + js[0]).GetValue("JavaHome") + "\\bin\\javaw.exe\nPlayer\n");
                sw.Close();
            }
            string[] Ct = new string[] { };
            Ct = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\HYMCLConfig.HYMCLConfig");
            mm.Text = Ct[0];
            jp.Text = Ct[1];
            un.Text = Ct[2];
        }
    

        private void browser_Click(object sender, RoutedEventArgs e)
        {
            //浏览部分
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();//初始化打开文件对话框
            ofd.Title = "请选择您的javaw.exe所在路径";//设置标题
            ofd.RestoreDirectory = true;//不还原路径
            ofd.Multiselect = false;//不允许选择多个
            ofd.Filter = "应用程序(javaw.exe)";//设置格式过滤
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {//显示对话框
                jp.Text = ofd.FileName;//返回路径名
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            //this.
            //写配置
            String[] Ct = new String[] { mm.Text, jp.Text, un.Text };//拼接配置文件内容
            File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\HYMCLConfig.HYMCLConfig", Ct);//写入
            System.Windows.Forms.MessageBox.Show("本地保存成功，云储存功能施工中(ง •̀_•́)ง", "云储存通知");
            //return;
            this.Close();//关闭窗体
        }
    }
}
