using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos y Constructores
        private int legajo;

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Universitario()
        {
        }
        /// <summary>
        /// Instancia un universitario
        /// </summary>
        /// <param name="legajo">Legado del universitario </param>
        /// <param name="nombre">Nombre del universitario</param>
        /// <param name="apellido">Apellido del universitario</param>
        /// <param name="dni">Dni del universitario</param>
        /// <param name="nacionalidad">Nacionalidad del universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos y Sobrecargas

        /// <summary>
        /// Genera un StringBuilder con los datos del universitario
        /// </summary>
        /// <returns>Una cadena de caracteres con los datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(base.ToString());
            cadena.Append($"Legajo Numero: {this.legajo}");
            return cadena.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Evalua si un objeto es del tipo Universitario
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True si coinciden, de lo contrario false/returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Evalua si 2 universitarios son iguales
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns>True si tienen el mismo tipo, y coinciden con el dni o legajo, de lo contrario false</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.Equals(pg2) && (pg1.Dni == pg2.Dni || pg1.legajo == pg2.legajo))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Evalua si 2 universitarios son distintos
        /// </summary>
        /// <param name="u1">Universitario a comparar</param>
        /// <param name="u2">Universitario a comparar</param>
        /// <returns>True si son distintos, de lo contrario false</returns>
        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return !(u1 == u2);
        }
        #endregion
    }
}
