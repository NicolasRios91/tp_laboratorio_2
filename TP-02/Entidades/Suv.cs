using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Suv"/>
        /// </summary>
        /// <param name="marca">valor a asignar al atributo <see cref="Vehiculo.EMarca"/></param>
        /// <param name="chasis">valor a asignar al atributo "chasis"</param>
        /// <param name="color">valor a asignar al atributo "color"</param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        /// <summary>
        /// Devuelve el tamaño de las camionetas (Grande)
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        /// <summary>
        /// Muestra los datos de la camioneta
        /// </summary>
        /// <returns>Listado del vehiculo <see cref="Suv"/></returns>
        public sealed override string Mostrar()
        {
            string v = (string)this;//me devuelve los datos de la clase base, con el formato del stringBuilder
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SUV");
            sb.AppendLine(v);
            sb.AppendLine(string.Format("TAMAÑO : {0}", this.Tamanio));
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
