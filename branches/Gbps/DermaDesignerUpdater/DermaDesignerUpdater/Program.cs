using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
namespace DermaDesignerUpdater
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Main MainForm = new Main();
            MainForm.BringToFront();
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            Application.Run(MainForm);
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.Contains("ICSharpCode.SharpZipLib"))
            {
                Byte[] buff = DermaDesignerUpdater.Properties.Resources.ICSharpCode_SharpZipLib; // Neat little trick to load the zip lib we need without needing the dll file on their computer ^-^
                return Assembly.Load(buff);
            }
           return null;
          } 

    }
}
