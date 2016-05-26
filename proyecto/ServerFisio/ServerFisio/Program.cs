using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ServerFisio.Interfaz;

namespace ServerFisio
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static Form vPrinc;
        [STAThread]  
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            VServidor v = new VServidor();
            vPrinc = v;
         
            Application.Run(v);
        
        }
    }
}
