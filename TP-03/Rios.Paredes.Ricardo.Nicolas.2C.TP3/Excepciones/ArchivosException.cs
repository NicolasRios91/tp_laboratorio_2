using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException()
            :base("Archivo incorrecto")
        {

        }
        public ArchivosException(Exception innerException)
            :base ("Archivo incorrecto",innerException)
        {
        }
        public ArchivosException(string message, Exception innerException)
            :base(message,innerException)
        {

        }
    }
}
