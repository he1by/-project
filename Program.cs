using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Data_base
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Cxml.CreateXmlFile(Application.StartupPath + "\\DateBase.txt");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
