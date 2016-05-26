using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using ClienteFisio.ClientWCF;
using ClienteFisio.ClientWCF;


namespace ClienteFisio
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
    
    public partial class App : Application
    {

        static private TFisioterapeuta fisioSesion;

        public static TFisioterapeuta FisioSesion
        {
            get { return App.fisioSesion; }
            set { App.fisioSesion = value; }
        }
       
       
 
    }
}
