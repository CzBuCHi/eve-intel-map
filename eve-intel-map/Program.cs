using System;
using System.Windows.Forms;

namespace eve_intel_map
{
    internal static class Program
    {
        [STAThread]
        private static void Main() {
            DbHelper.EnsureDatatabaseExists();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
