using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace JuicyLauncher
{
    class Launcher
    {
        /// <summary>
        /// 启动主方法
        /// </summary>
        /// <param name="MaxMem">最大内存</param>
        /// <param name="JavaPath">Javaw.exe路径</param>
        /// <param name="UserName">用户名</param>
        /// <param name="VerName">版本名</param>
        public void Launch(string MaxMem, string JavaPath, string UserName, string VerName)
        {
            string rtxt = "";
            int tmp = 0;
            rtxt = File.ReadAllText(Application.StartupPath + "\\.minecraft\\versions\\" + VerName + "\\" + VerName + ".json").Replace(" ", "").Replace("\n", "");//读取内容
            tmp = rtxt.IndexOf("mainClass") + "mainClass".Length + 3;
            String mainClass = rtxt.Substring(tmp, rtxt.IndexOf("\"", tmp) - tmp);
            tmp = rtxt.IndexOf("minecraftArguments") + "minecraftArguments".Length + 3;
            String minecraftArguments = rtxt.Substring(tmp, rtxt.IndexOf("\"", tmp) - tmp).Replace("${", " ${").Replace("}", "} ");
            tmp = rtxt.IndexOf("libraries") + "libraries".Length + 3;
            String libraries = rtxt.Substring(tmp, rtxt.LastIndexOf("]") - tmp);
            String[] libs = libraries.Split("},{".ToCharArray());
            String libp = "";
            for (int i = 1; i < libs.Length; i++)
            {
                if (libs[i].IndexOf("name") == -1)
                {
                    continue;
                }
                tmp = libs[i].IndexOf("name") + "name".Length + 3;
                String libn = libs[i].Substring(tmp, libs[i].IndexOf("\"", tmp) - tmp);
                if (libn.IndexOf(":") == -1)
                {
                    continue;
                }
                String[] tlib = new String[] { libn.Substring(0, libn.IndexOf(":")).Replace(":", ""), libn.Substring(libn.IndexOf(":") + 1, libn.IndexOf(":", libn.IndexOf(":") + 1) - libn.IndexOf(":")).Replace(":", ""), libn.Substring(libn.IndexOf(":", libn.IndexOf(":") + 1)).Replace(":", "") };
                String tpath = Application.StartupPath + "\\.minecraft\\libraries\\" + tlib[0].Replace(".", "\\") + "\\" + tlib[1] + "\\" + tlib[2] + "\\" + tlib[1] + "-" + tlib[2] + ".jar";
                if (File.Exists(tpath))
                {
                    libp = libp + tpath + ";";
                }
            }
            String natives = Application.StartupPath + "\\.minecraft\\versions\\" + VerName + "\\" + VerName + "-natives";
            libp = libp + Application.StartupPath + "\\.minecraft\\versions\\" + VerName + "\\" + VerName + ".jar";
            String assets = Application.StartupPath + "\\.minecraft\\assets";
            String gameDir = Application.StartupPath + "\\.minecraft";
            if (Application.StartupPath.IndexOf(" ") != -1)
            {
                natives = "\"" + natives + "\"";
                libp = "\"" + libp + "\"";
                assets = "\"" + assets + "\"";
                gameDir = "\"" + gameDir + "\"";
            }
            minecraftArguments = minecraftArguments.Replace("${auth_player_name}", UserName).Replace("${version_name}", "HYMCLauncher").Replace("${game_directory}", gameDir).Replace("${game_assets}", assets);
            //启动参数拼接
            String RunComm = "";
            RunComm = "-Xmx" + MaxMem + "m -Djava.library.path=" + natives + " -Dfml.ignoreInvalidMinecraftCertificates=true -Dfml.ignorePatchDiscrepancies=true -cp " + libp + " " + mainClass + " " + minecraftArguments;
            Process mjp = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(JavaPath, RunComm);
            psi.UseShellExecute = false;
            mjp.StartInfo = psi;
            mjp.Start();
            //MessageBox.Show(RunComm);
            Application.Exit();
        }
    }
}
