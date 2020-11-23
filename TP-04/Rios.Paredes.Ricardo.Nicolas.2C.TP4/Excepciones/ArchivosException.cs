using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Clase para manejar las Excepcione relacionadas con archivos
    /// </summary>
    public class ArchivosException : Exception
    {
        public ArchivosException()
            :base ("Archivo incorrecto")
        {

        }
        public ArchivosException(Exception innerException)
            :base("Archivo incorrecto", innerException)
        {

        }
        public ArchivosException(string msj,Exception innerException)
        :base(msj,innerException)
        {

        }
    }
}
