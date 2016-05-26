using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClienteFisio.ClientWCF;
using System.ServiceModel;

namespace ClienteFisio
{
    public class ClienteWCF
    {
        private static ServiciosClient s = null;
        private ClienteWCF()
        {
        }
        public static ServiciosClient getServicios()
        {
            if (s == null)
                s = new ServiciosClient();
            
            s.Endpoint.Address = new EndpointAddress("http://"+ClienteFisio.Properties.Settings.Default.ServerFisioIp+":"+ClienteFisio.Properties.Settings.Default.ServerFisioPort+"/ServerFisio/Servicios");
            return s;
           
        }

        public static void recon()
        {
            s = new ServiciosClient();

            s.Endpoint.Address = new EndpointAddress("http://" + ClienteFisio.Properties.Settings.Default.ServerFisioIp + ":" + ClienteFisio.Properties.Settings.Default.ServerFisioPort + "/ServerFisio/Servicios");
            
        }
    }
}
