using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Sinuosity
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.PlaceholderMenu());
        }
    }
}
