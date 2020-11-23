using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Clase para manejar las ventas que superen el limite de cantidad
    /// </summary>
    public class CantidadLimiteException : Exception
    {
        public CantidadLimiteException()
            :this("Se supero el limite de unidades permitido")
        {

        }

        public CantidadLimiteException(string msj)
            :this(msj,null)
        {

        }

        public CantidadLimiteException(string msj, Exception innerException)
            :base(msj,innerException)
        {

        }
    }
}
