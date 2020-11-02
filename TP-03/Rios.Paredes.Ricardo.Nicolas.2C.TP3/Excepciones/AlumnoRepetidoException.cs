using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion para el caso donde el alumno se repita
    /// </summary>
    public class AlumnoRepetidoException : Exception
    {
        public AlumnoRepetidoException()
            :base("Alumno Repetido")
        {   
        }
        public AlumnoRepetidoException(string message)
            :base(message)
        {
        }

            
        
    }
}
