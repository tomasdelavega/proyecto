using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerFisio.Excepciones
{
  
    public class ErrorDatosExistentesException : Exception
    {
        public ErrorDatosExistentesException()
            : base("Error: datos ya existentes")
        {
        }

        public ErrorDatosExistentesException(String message)
            : base(message)
        {
        }
    }
}
