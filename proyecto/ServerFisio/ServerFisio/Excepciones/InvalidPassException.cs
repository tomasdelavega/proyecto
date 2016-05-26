using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ServerFisio.Excepciones
{
    
  
    public class InvalidPassException:Exception
    {
        private string _descripcion;
        public InvalidPassException()
            : base("Contraseña incorrecta")
        { }

    }
}
