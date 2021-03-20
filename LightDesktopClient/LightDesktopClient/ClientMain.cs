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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
        }
    }
}
