using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ServerFisio.DTO
{
 
 // [DataContract]
    public class LineaPedidoDTO
    {
        private int cantidad;
        private float precio;
        private MaterialDTO material;
        

       
      //  [DataMember]
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

     //   [DataMember]
        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }

      //  [DataMember]
        public MaterialDTO Material
        {
            get { return material; }
            set { material = value; }
        }
        
    }
}
