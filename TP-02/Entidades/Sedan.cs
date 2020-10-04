using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        /// <summary>
        /// Enumerado del tipo de automovil segun la cantidad de puertas
        /// </summary>
        public enum ETipo { CuatroPuertas, CincoPuertas }
        ETipo tipo;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Sedan"/>
        /// </summary>
        /// <param name="marca">valor a asignar al atributo <see cref="Vehiculo.EMarca"/></param>
        /// <param name="chasis">valor a asignar al atributo "chasis"</param>
        /// <param name="color">valor a asignar al atributo "color"</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            
        }
        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Sedan"/>
        /// </summary>
        /// <param name="marca">valor a asignar al atributo "marca"</param>
        /// <param name="chasis">valor a asignar al atributo "chasis"</param>
        /// <param name="color">valor a asignar al atributo "color"</param>
        /// <param name="tipo">valor a asignar al atributo "tipo"</param>
        public Sedan(EMarca marca,string chasis,ConsoleColor color,ETipo tipo)
            :this(marca,chasis,color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Devuelve el tamaño de los automoviles (Son MEDIANOS)
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Muestra los datos del automovil
        /// </summary>
        /// <returns>Listado del vehiculo <see cref="Sedan"/></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);//con "\n" antes de "TIPO" queda mas prolijo
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
