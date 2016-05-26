using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ServerFisio.Excepciones
{
    [DataContract]
    public class Error
    {
        private String content;

        [DataMember]
        public String Content
        {
          get { return content; }
          set { content = value; }
        }
        
       
    }
}
