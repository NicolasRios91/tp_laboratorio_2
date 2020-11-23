using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Clase para manejar los productos que sean repetidos
    /// </summary>
    public class ProductoRepetidoException : Exception
    {
        public ProductoRepetidoException()
        {

        }
        public ProductoRepetidoException(string msj)
            :base(msj)
        {

        }
        public ProductoRepetidoException(string msj,Exception innerException)
            :base(msj,innerException)
        {

        }
    }
}
