using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion para el caso donde el dni y la nacionalidad no coincidan
    /// </summary>
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException()
            :base("La nacionalidad no se coincide con el numero de DNI")
        {
        }
        public NacionalidadInvalidaException(string message)
            :base(message)
        {
        }

        public NacionalidadInvalidaException(string message,Exception innerException)
            :base(message,innerException)
        {

        }

    }
}
