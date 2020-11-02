using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion para el caso en el que el Dni no sea valido
    /// </summary>
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException()
            :base("El dni es invalido")
        {
        }

        public DniInvalidoException(string message)
            : base(message)
        {

        }
        public DniInvalidoException(string message, Exception e)
            : base(message, e)
        {

        }
        public DniInvalidoException(Exception e)
            :this("El dni es invalido",e)
        {
        }



    }
}
