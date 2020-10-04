using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Ciclomotor"/> 
        /// </summary>
        /// <param name="marca">valor a asignar al atributo <see cref="Vehiculo.EMarca"/></param>
        /// <param name="chasis">valor a asignar al atributo "chasis"</param>
        /// <param name="color">valor a asignar al atributo "color"</param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            :base(chasis,marca,color)
        {
        }

        /// <summary>
        /// Devuelve el tamaño de las motos (chicas)
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Muestra los datos de la moto
        /// </summary>
        /// <returns>Listado del vehiculo <see cref="Ciclomotor"/></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            string c = (string)this;
            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(c);
            sb.AppendLine(string.Format("TAMAÑO : {0}", this.Tamanio));
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
