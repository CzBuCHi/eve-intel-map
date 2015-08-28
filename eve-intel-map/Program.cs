using System;
using System.Windows.Forms;

namespace eve_intel_map
{
    internal static class Program
    {
        [STAThread]
        private static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
