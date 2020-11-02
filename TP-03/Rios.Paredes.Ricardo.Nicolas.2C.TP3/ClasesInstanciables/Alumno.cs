using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Enumerados y Atributos
        /// <summary>
        /// Estados de cuenta del alumno
        /// </summary>
        public enum EEstadoCuenta { AlDia,Deudor,Becado};

        private Universidad.EClases claseQueToma; 
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Alumno()
        {
        }
        /// <summary>
        /// Instancia un Alumno
        /// </summary>
        /// <param name="id">Legajo del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">Dni del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma</param>
        public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad,Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Instancia un Alumno
        /// </summary>
        /// <param name="id">Legajo del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">Dni del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma</param>
        /// <param name="estadoCuenta">Estado de su cuenta</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta)
            :this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos y Sobrecargas

        /// <summary>
        /// Genera un StringBuilder con los datos del alumno
        /// </summary>
        /// <returns>Cadena de caracteres con los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(base.MostrarDatos());
            cadena.Append("Estado de cuenta: ");
            if (this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                cadena.AppendLine("Cuota al dia");
            }
            else
            {
                cadena.AppendLine($"{this.estadoCuenta}");
            }
            
            cadena.AppendLine(this.ParticiparEnClase());
            return cadena.ToString();
        }

        /// <summary>
        /// Muestra los datos del alumno
        /// </summary>
        /// <returns>Cadena de caracteres con los datos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Evalua si un alumno toma una clase
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>true si el alumno toma la clase y su estado de cuenta no es deudor, caso contrario false</returns>
        public static bool operator ==(Alumno a,Universidad.EClases clase)
        {
            if (a.estadoCuenta != EEstadoCuenta.Deudor && a.claseQueToma == clase)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Evalua si un alumno no toma una clase
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>true si el alumno no toma la clase, false si la toma</returns>

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma != clase);
        }

        /// <summary>
        /// Devuelve la clase que toma el alumno
        /// </summary>
        /// <returns>Cadena de caracteres con la clase que toma</returns>
        protected override string ParticiparEnClase()
        {
            return $"Toma clase de: {this.claseQueToma}";
        }
        #endregion
    }
}
