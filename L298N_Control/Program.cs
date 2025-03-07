using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L298N_Control
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            SplashScreen splashScreen = new SplashScreen();
            if (splashScreen.ShowDialog() == DialogResult.OK)
                Application.Run(new Form1());

        }
    }
}
