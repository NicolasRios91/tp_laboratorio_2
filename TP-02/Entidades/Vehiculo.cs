using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        /// <summary>
        /// Enumerado de marcas del vehiculo
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }

        /// <summary>
        /// Enumerado de tamaños del vehiculo
        /// </summary>
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }

        //ATRIBUTOS
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;

        /// <summary>
        /// Constructor base
        /// </summary>
        /// <param name="chasis">valor a asignar al atributo "chasis"</param>
        /// <param name="marca">valor a asignar al atributo "marca"</param>
        /// <param name="color">valor a asignar al atributo "color" </param>
        public Vehiculo(string chasis,EMarca marca,ConsoleColor color)
        {
            this.color = color;
            this.chasis = chasis;
            this.marca = marca;
        }

        /// <summary>
        /// Retorna el tamaño del vehiculo
        /// </summary>
        protected abstract ETamanio Tamanio { get;}

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>Listado del vehiculo</returns>
        public virtual string Mostrar()
        {
            //string a = (string)this;

            return (string)this; //utilizo el casteo para devolver el stringbuilder con los datos
        }


        /// <summary>
        /// Castea los datos de un Vehiculo a una cadena de caracteres
        /// </summary>
        /// <param name="p">Vehiculo a exponer</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("CHASIS: {0}\r", p.chasis.ToString()));
            sb.AppendLine(string.Format("MARCA : {0}\r", p.marca.ToString()));
            sb.AppendLine(string.Format("COLOR : {0}\r", p.color.ToString()));
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Primer vehiculo a comparar</param>
        /// <param name="v2">Segundo vehiculo a comparar</param>
        /// <returns>True si son iguales, false si son distintos</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Primer vehiculo a comparar</param>
        /// <param name="v2">Segundo vehiculo a comparar</param>
        /// <returns>True si son distintos, false si son iguales</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis != v2.chasis);
        }
    }
}
