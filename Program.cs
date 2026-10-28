using System;
using System.Windows.Forms;
using Lab07_ADONET_Connection.GUI;

namespace Lab07_ADONET_Connection
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
