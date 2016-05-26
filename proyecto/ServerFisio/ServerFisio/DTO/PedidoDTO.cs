using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ServerFisio.DTO
{
   // [DataContract]
    public class PedidoDTO
    {
        private int id;
        private String observaciones;
        private DateTime fecha;
        private List<LineaPedidoDTO> lineasPedido;

   
     //   [DataMember]
        public List<LineaPedidoDTO> LineasPedido
        {
            get { return lineasPedido; }
            set { lineasPedido = value; }
        }


      //  [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

       // [DataMember]
        public String Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

      //  [DataMember]
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

    }
}
