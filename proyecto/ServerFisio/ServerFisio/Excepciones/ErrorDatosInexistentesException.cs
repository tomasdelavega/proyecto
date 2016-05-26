using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerFisio.Excepciones
{
   
    public class ErrorDatosInexistentesException : Exception
    {
     
        public ErrorDatosInexistentesException()
            : base("No se encuentran los datos en la BBDD")
        {
        }

        public ErrorDatosInexistentesException(String msg)
            : base(msg)
        {
        }
    }
}
