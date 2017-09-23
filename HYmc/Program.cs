using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HYmc
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SplashScreen splashScreen = new SplashScreen("index.gif");
            splashScreen.Show(false);
            splashScreen.Close(new TimeSpan(0, 0, 5));
            App app = new App();
            app.Run(new MainWindow());
        }
    }
}
