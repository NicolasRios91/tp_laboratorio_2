using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion para el caso donde no exista un profesor para una clase
    /// </summary>
    public class SinProfesorException : Exception
    {
        public SinProfesorException()
            :base("No hay profesor para la clase")
        {

        }
        public SinProfesorException(string message)
            :base(message)
        {
        }
    }
}
