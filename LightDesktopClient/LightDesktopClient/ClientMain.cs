using LightDesktop.Core;
using System;
using System.Windows.Forms;

namespace LightDesktopClient
{
    static class ClientMain
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LightDesktopCore.Launch(args);
        }
    }
}
