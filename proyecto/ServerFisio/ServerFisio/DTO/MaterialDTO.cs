using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ServerFisio.DTO
{
   // [DataContract]
    public class MaterialDTO
    {
        private int id;
        private String nombre;

       // [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
      //  [DataMember]
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


    }
}
